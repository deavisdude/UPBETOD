Shader "Custom/Black Hole (Live) v2"{
	Properties{
	_Horizon("Event Horizon", Range(0.01, 1)) = 0.1
	_Scale("Effect Scale", float) = 1
	}

	SubShader{
		Tags{ "Queue" = "Transparent" }
		GrabPass{}
		Pass{
			ZWrite Off
			Lighting Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag
			#pragma debug

			#include "UnityCG.cginc"

			// User-specified uniforms
			float _Horizon;
			float _Scale;
			sampler2D _GrabTexture;
			
			struct vertexInput{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput{
				float4 position : SV_POSITION;
				float4 vertex : TEXCOORD2;
				float3 normalDir : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
			};

			vertexOutput vert(vertexInput input){
				vertexOutput output;
				output.position = mul(UNITY_MATRIX_MVP, input.vertex);
				output.viewDir = mul(_Object2World, input.vertex).xyz - _WorldSpaceCameraPos;
				output.normalDir = normalize(mul(float4(input.normal, 0), _World2Object).xyz);
				//output.vertex = mul(_Object2World, input.vertex);
				output.vertex = input.vertex;
				return output;
			}
			
			float2 screenPosition(float4 direction){
				float2 position = direction.xy / direction.w;
				position.x = (position.x + 1) * 0.5;
				position.y = 1 - (position.y + 1) * 0.5;
				return position;
			}
			
			float3x3 generateMatrix(float3 axis, float angle){
				float sina = sin(angle);	float cosa = 1 - cos(angle);
				float x = axis.x;	float y = axis.y;	float z = axis.z;
				float x2 = axis.x * axis.x;	float y2 = axis.y * axis.y;	float z2 = axis.z * axis.z;
				
				float3x3 result = float3x3(
				1 - cosa + x2 * cosa,		x * y * cosa - z * sina,	x * z * cosa + y * sina,
				y * x * cosa + z * sina,	1 - cosa + y2 * cosa,		y * z * cosa - x * sina,
				z * x * cosa - y * sina,	z * y * cosa + x * sina,	1 - cosa + z2 * cosa
				);
				return result;
			}

			float4 frag(vertexOutput input) : COLOR{
				float4 result = float4(0, 0, 0, 1);
				float2 impact = screenPosition(mul(UNITY_MATRIX_MVP, input.vertex));
					//	^ Screen position of the vertex.
				float2 center = screenPosition(mul(UNITY_MATRIX_MVP, float4(0,0,0,1)));
					//	^ Screen position of the object.
				float aspect = _ScreenParams.x / _ScreenParams.y;
				impact.x *= aspect;
				center.x *= aspect;	//	Adjustments for aspect ratio
				float viewDistance  = unity_OrthoParams.y * 4;
				if(unity_OrthoParams.w == 0)	viewDistance = distance(input.vertex, _WorldSpaceCameraPos) * 2.31;
				float3 impactParameter = float3(0, 0, 0);
				impactParameter.xy = (impact - center) / _Scale;	//	The effect is scalable to work with black holes in scaled space.
				float warp = saturate(1 - length(impactParameter.xy) * viewDistance);
				warp = saturate(warp / (1 - _Horizon));
				float angle = 16 * warp * warp / viewDistance;
				float threshold = 360;
				if(unity_OrthoParams.w == 0)	threshold = 90;
				if(angle < radians(threshold) && warp < 1){	//	Refraction angle is under 180 degrees and below the manual threshold
					float3 axis = normalize(cross(impactParameter, float3(0, 0, 1)));	//	This may need to be flipped
					axis = mul(UNITY_MATRIX_V, axis);
					float3x3 rotationMatrix = generateMatrix(axis, angle);
					//rotationMatrix = mul(UNITY_MATRIX_V, rotationMatrix);
					if(false && unity_OrthoParams.w == 0){	//	Perspective projection
						float3 refractedDir = float3(0, 0, 0);
						refractedDir = mul(rotationMatrix, input.viewDir);
						result = tex2D(_GrabTexture, screenPosition(mul(UNITY_MATRIX_VP, refractedDir)));
					}else{	//	Orthographic projection
						float2 refractedPos = impact - center;
						refractedPos *= 1 - warp * warp * 4;
						refractedPos += center;
						refractedPos.x /= aspect;
						result = tex2D(_GrabTexture, refractedPos);
					}
				}
				result.a = saturate((1 - length(impactParameter.xy) * viewDistance) * 100);
				
				//	Debug options
				//result.rgb = warp % 1;
				//result.rgb =  tex2D(_GrabTexture, screenPosition(mul(UNITY_MATRIX_VP, input.viewDir)));
				//result.rgb = 0;
				//if(warp < 1)	result.rgb += floor((1 - warp * 10 % 1) + 0.01) * 0.25;
				//if(warp > 0 && warp < 0.1)	result.r += 0.1;
				//if(warp > 0.498 && warp < 0.502)	result.g = 0.5;
				//result.rgb *= 2;
				//result.rgb = 0.8;
				//if(warp > 0.001)	result.a = (1 - warp * 10 % 1) / 10;
				//result.a *= 0.5;
				//if(warp < 0.001)	result = float4(0.5, 0.5, 0.5, 0.5);
				
				return result;
			}
			
			ENDCG
		}
	}
	Fallback "Diffuse"
}