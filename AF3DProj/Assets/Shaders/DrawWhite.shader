Shader "Unlit/DrawWhite"
{
	SubShader
	{
		ZWrite Off
		ZTest Always
		Lighting Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct v2f
			{
				float4 vertex : POSITION;
			};
			
			v2f vert (v2f v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			half4 frag (v2f i) : COLOR0
			{
				return half4(1,1,1,1);
			}
			ENDCG
		}
	}
}
