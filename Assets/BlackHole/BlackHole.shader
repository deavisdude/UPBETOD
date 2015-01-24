Shader "Black Hole" {
   Properties {
      _Cube("Reflection Map", Cube) = "" {}
      _RefractiveIndex("Refractive Index", Float) = 1.5
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
	 float _RefractiveIndex;
 
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
 
            float4x4 modelMatrix = _Object2World;
            float4x4 modelMatrixInverse = _World2Object; 
               // multiplication with unity_Scale.w is unnecessary 
               // because we normalize transformed vectors
 
            output.viewDir = mul(modelMatrix, input.vertex).xyz 
               - _WorldSpaceCameraPos;
            output.normalDir = normalize(
               mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
	    float fleb = dot(normalize(input.viewDir), normalize(input.normalDir));
	    fleb = pow(fleb, _RefractiveIndex);
            float3 refractedDir = refract(normalize(input.viewDir), 
               normalize(input.normalDir), 1 / (1 + fleb));
	    float4 colorAdjust = (1, 1, 1, 1);
	    if(fleb >= 1 - 2 / _RefractiveIndex) colorAdjust = (0, 0, 0, 0);
	    colorAdjust.a = clamp(fleb * _RefractiveIndex, 0, 1);
	    return texCUBE(_Cube, refractedDir) * colorAdjust;
         }
 
         ENDCG
      }
   }
}