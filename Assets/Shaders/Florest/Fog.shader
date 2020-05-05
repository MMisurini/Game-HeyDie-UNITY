Shader "Custom/Fog" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_QOffset("Offset", Vector) = (0,0,0,0)
		_Dist("Distance", Float) = 100.0
	}
		SubShader{
			Tags { "RenderType" = "transparent" "IgnoreProjector" = "True" }
			Pass
			{
				CGPROGRAM
				#include "UnityCG.cginc"
				#pragma vertex vert addshadow
				#pragma fragment frag
				#pragma multi_compile_fog
				#pragma multi_compile LIGHTMAP_ON LIGHTMAP_OFF

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _QOffset;
				float _Dist;

				struct appdata_t {
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
					float2 texcoord1 : TEXCOORD1;
				};

				struct v2f {
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
					half2 uv2 : TEXCOORD1;
					UNITY_FOG_COORDS(2)
				};

				v2f vert(appdata_t v)
				{
					v2f o;
					float4 vPos = mul(UNITY_MATRIX_MV, v.vertex);
					float zOff = vPos.z / _Dist;
					vPos += _QOffset * zOff * zOff;

					o.vertex = mul(UNITY_MATRIX_P, vPos);
					o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
					o.uv2 = v.texcoord;

					#ifdef LIGHTMAP_ON
					  o.uv2 = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
					 #endif
					UNITY_TRANSFER_FOG(o,o.vertex);

					return o;
				}

				half4 frag(v2f i) : COLOR
				{
					half4 col = tex2D(_MainTex, i.uv.xy);
					#ifdef LIGHTMAP_ON
					 half4 lm = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2);
					 col.rgb = col.rgb * DecodeLightmap(lm);
						col *= UNITY_LIGHTMODEL_AMBIENT * 10;
					   #endif

					UNITY_APPLY_FOG(i.fogCoord, col);
					UNITY_OPAQUE_ALPHA(col.a);

					return col;
				}
				ENDCG
			}
		}
			FallBack "Diffuse"
}