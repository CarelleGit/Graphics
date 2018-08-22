Shader "Custom/WetSurface" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Diffuse Texture (RGB), Alpha (A)", 2D) = "white" {}
	    _NormalText("Normal Texture (RGB), Specular Texture (A)",2D) = "white"{}
		_LightPower("Light Power", float) = 1
		/*_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0*/
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows


		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		half4 _Color;
		sampler2D _NormalTex;
		half _LightPower;

		struct Input 
		{
			float2 uv_MainTex;
		};
		half halfDot(half3 a, half3 b)
		{
			return dot(normalize(a), normalize(b)) * 0.5f + 0.5f;
		}
		half4 lightingHalfLambert(SurfaceOutputStandard o, half3 lightDir, half3 viewDir, half atten)
		{
			half shadingValue = halfDot(o.Normal, lightDir);
			half3  diffuseLighting = shadingValue * o.Albedo * _LightColor0;
			half3 returnColor = diffuseLighting * atten * _LightPower;

			return half4(returnColor, o.Alpha);
		}
		
		

		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			half4 diffuseValue = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = diffuseValue.rgb;
			
			o.Alpha = diffuseValue.a;

			half3 normalValue = UnpackNormal(tex2D(_NormalTex, IN.uv_MainTex));
			o.Normal = normalValue.rbg;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
