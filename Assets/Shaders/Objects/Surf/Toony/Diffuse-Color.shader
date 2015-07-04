Shader "Aubergine/Objects/Surf/Toony/Diffuse-Color" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MainColor("Color Tint", Color) = (0,0,0,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		//Absolute path
		#include "Assets/Shaders/Includes/Aubergine_Lights.cginc"
		//Or you can use relative path as below, whatever suits you
		//#include "../../../Includes/Aubergine_Lights.cginc"
		#pragma surface surf Aub_Toon

		sampler2D _MainTex;
		fixed4 _MainColor;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			c.rgb *= _MainColor;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}