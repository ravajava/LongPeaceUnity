Shader "Custom/PP_Outline"
{
	Properties
	{
		_MainTex("Main Texture",2D) = "black"{}
		_SceneTex("Scene Texture",2D) = "black"{}
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float2 _MainTex_TexelSize;

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uvs : TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uvs = TRANSFORM_TEX(v.texcoord, _MainTex);
				#if UNITY_UV_STARTS_AT_TOP
					o.uvs.y = 1 - o.uvs.y;
				#endif
				return o;
			}


			half frag(v2f i) : COLOR
			{
				int numberOfIterations = 20;
				float texelX = _MainTex_TexelSize.x;
				float colorIntensityInRadius;

				for (int k = 0; k < numberOfIterations; k ++)
				{
					colorIntensityInRadius += tex2D(
					_MainTex,
					i.uvs.xy + float2(
					(k - numberOfIterations / 2) * texelX, 0)
					).r / numberOfIterations;
				}
				return colorIntensityInRadius;
			}
			ENDCG
		}   

		GrabPass{}

		Pass
		{
			CGPROGRAM

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _SceneTex;
			sampler2D _GrabTexture;
			float2 _GrabTexture_TexelSize;

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uvs : TEXCOORD0;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uvs = TRANSFORM_TEX(v.texcoord, _MainTex);
				//#if UNITY_UV_STARTS_AT_TOP
				//	o.uvs.y = 1 - o.uvs.y;
				//#endif
				return o;
			}


			half4 frag(v2f i) : COLOR
			{
				int numberOfIterations = 20;
				float texelY = _GrabTexture_TexelSize.y;
				half colorIntensityInRadius = 0;

				if (tex2D(_MainTex, i.uvs.xy).r > 0)
				{
					return tex2D(_SceneTex, float2(i.uvs.x, i.uvs.y));
				}

				for (int j = 0; j < numberOfIterations; ++j)
				{
					colorIntensityInRadius += tex2D(
						_GrabTexture,
						float2(i.uvs.x, i.uvs.y) + 
						float2(0, (j - numberOfIterations / 2) * texelY)
					).r / numberOfIterations;
				}

				half4 outcolor = colorIntensityInRadius * half4(0,1,1,1) * 2 + (1 - colorIntensityInRadius) * tex2D(_SceneTex, float2(i.uvs.x, i.uvs.y));
				return outcolor;
			}
			ENDCG
		}  
	}
}