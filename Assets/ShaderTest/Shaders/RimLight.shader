﻿Shader "Custom/RimLight"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_NormalMapIntensity("Nomal power", Range(0,3))= 1

		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimPower("Rim Power", Range(0.5,8.0)) = 6.0

		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque " }
		LOD 200



		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		fixed _NormalMapIntensity;
		fixed4 _Color;
		fixed4 _RimColor;
		fixed _RimPower;
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)


		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			
			// Bump mapping
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			o.Normal.x *= _NormalMapIntensity;
			o.Normal.y *= _NormalMapIntensity;

			// Rim Light
			half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
			
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
