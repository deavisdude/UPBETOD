Shader "Black Hole" {
   Properties {
      _Cube("Environment Map", Cube) = "" {}
      _DistortionPower("Distortion Power", Float) = 10
   }

   SubShader {
      Tags{ "Queue" = "Transparent" }
      Pass {
         ZWrite Off
	 Blend SrcAlpha OneMinusSrcAlpha
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
 
         // User-specified uniforms
         uniform samplerCUBE _Cube;
	 float _DistortionPower;
 
         struct vertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
         };
	 
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float3 normalDir : TEXCOORD0;
            float3 viewDir : TEXCOORD1;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
            output.viewDir = mul(_Object2World, input.vertex).xyz - _WorldSpaceCameraPos;
	    //output.viewDir = (output.viewDir + float3(0, 0, 10)) * 0.5;
            output.normalDir = normalize(mul(float4(input.normal, 0), _World2Object).xyz);
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
	    float warp = dot(normalize(input.viewDir), normalize(input.normalDir));
	    warp = pow(abs(warp), _DistortionPower);
	    float3 refractedDir = refract(normalize(input.viewDir), normalize(input.normalDir), 1 / (1 + warp));
	    refractedDir.z *= -1;
	    float4 result = texCUBE(_Cube, refractedDir);
	    if(warp >= 1 - 2 / _DistortionPower) result = float4(0, 0, 0, 1);
	    result.a = clamp(warp * _DistortionPower, 0, 1);
	    return result;
	 }
 
         ENDCG
      }
   }
}