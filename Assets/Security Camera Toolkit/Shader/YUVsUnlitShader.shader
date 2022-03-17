Shader "Unlit/YUVsUnlitShader"
{
	Properties
	{
		[HideInInspector][NoScaleOffset]_YTexture("Texture",2D) = ""{}
		[HideInInspector][NoScaleOffset]_UTexture("Texture",2D) = ""{}
		[HideInInspector][NoScaleOffset]_VTexture("Texture",2D) = ""{}
		[Toggle(_Filp_Y_ON)]  _ToggleForY("Enable Y Flip", Float) = 1
		[Toggle(_Filp_X_ON)]  _ToggleForX("Enable X Flip", Float) = 0

			//MASK SUPPORT ADD
			_StencilComp("Stencil Comparison", Float) = 8
			_Stencil("Stencil ID", Float) = 0
			_StencilOp("Stencil Operation", Float) = 0
			_StencilWriteMask("Stencil Write Mask", Float) = 255
			_StencilReadMask("Stencil Read Mask", Float) = 255
			_ColorMask("Color Mask", Float) = 15
			//MASK SUPPORT END
	}
		SubShader
		{
			Tags {"QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Cull off
			LOD 100

			//MASK SUPPORT ADD
			Stencil
			{
				Ref[_Stencil]
				Comp[_StencilComp]
				Pass[_StencilOp]
				ReadMask[_StencilReadMask]
				WriteMask[_StencilWriteMask]
			}
			ColorMask[_ColorMask]
			//MASK SUPPORT END

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag 
				#pragma multi_compile _ _Filp_X_ON
				#pragma multi_compile _ _Filp_Y_ON 
				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				sampler2D _YTexture;
				sampler2D _UTexture;
				sampler2D _VTexture;

				float4 _MainTex_ST;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;

#if !UNITY_UV_STARTS_AT_TOP
					o.uv.y = 1 - v.uv.y;
#endif
					//竖直反转图像
					#if _Filp_Y_ON
					o.uv.y = 1 - o.uv.y;
					#endif

					#if _Filp_X_ON
					o.uv.x = 1 - o.uv.x;
					#endif
					return o;
				}

				half3 yuv2rgb(float3 yuv)
				{
					// The YUV to RBA conversion, please refer to: http://en.wikipedia.org/wiki/YUV
					// Y'UV420p (I420) to RGB888 conversion section.
					half y_value = yuv[0];
					half u_value = yuv[1];
					half v_value = yuv[2];
					half r = y_value + 1.370705 * (v_value - 0.5);
					half g = y_value - 0.698001 * (v_value - 0.5) - (0.337633 * (u_value - 0.5));
					half b = y_value + 1.732446 * (u_value - 0.5);
					return half3(r, g, b);
				}



				//fixed4 frag(v2f i) : SV_Target
				//{
				//	fixed4 col = fixed4(0, 0, 0, 1);
				//	float y = clamp(tex2D(_YTexture, i.uv).w,0,1);
				//	float u = clamp(tex2D(_UTexture, i.uv).w,0,1);
				//	float v = clamp(tex2D(_VTexture, i.uv).w,0,1);
				//	col.x =y + 1.4022 * v - 0.7011;
				//	col.y = y - 0.3456 * u - 0.7145 * v + 0.53005;
				//	col.z =y + 1.771 * u - 0.8855;
				//	return col;
				//}

				fixed4 frag(v2f i) : SV_Target
				{
					half3 yuv;
					yuv.x = tex2D(_YTexture, i.uv).w;
					yuv.y = tex2D(_UTexture, i.uv).w;
					yuv.z = tex2D(_VTexture, i.uv).w;
					return fixed4(yuv2rgb(yuv), 1.0);
				}


				ENDCG
			}
		}
}
