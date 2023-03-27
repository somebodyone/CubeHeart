Shader "Unlit/CloudShader"
{
	Properties{
	   _MainTex("MainTex", 2D) = "white" {}
	   _BmpTex("BmpTex",2D) = "white"{}
	   _Color("Color", Color) = (1,1,1,1)
	   _Speed("Speed",Float) = 1
	   [HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	   [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
	}
		SubShader{
			Tags {
				"IgnoreProjector" = "True"
				"Queue" = "Transparent"
				"RenderType" = "Transparent"
				"CanUseSpriteAtlas" = "True"
				"PreviewType" = "Plane"
			}
			Pass {
				Name "FORWARD"
				Tags {
					"LightMode" = "ForwardBase"
				}
				Blend One OneMinusSrcAlpha
				Cull Off
				ZWrite Off

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#define UNITY_PASS_FORWARDBASE
				#pragma multi_compile _ PIXELSNAP_ON
				#include "UnityCG.cginc"
				#pragma multi_compile_fwdbase
				#pragma only_renderers d3d9 d3d11 glcore gles 
				#pragma target 3.0
				uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
				uniform float4 _Color;
				sampler2D _BmpTex;
				float4 _BmpTex_ST;
				float _Speed;
				struct VertexInput {
					float4 vertex : POSITION;
					float2 texcoord0 : TEXCOORD0;
					float4 vertexColor : COLOR;
				};
				struct VertexOutput {
					float4 pos : SV_POSITION;
					float2 uv0 : TEXCOORD0;
					float4 vertexColor : COLOR;
				};
				VertexOutput vert(VertexInput v) {
					VertexOutput o = (VertexOutput)0;
					o.uv0 = v.texcoord0;
					o.vertexColor = v.vertexColor;
					o.pos = UnityObjectToClipPos(v.vertex);
					#ifdef PIXELSNAP_ON
						o.pos = UnityPixelSnap(o.pos);
					#endif
					return o;
				}
				float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
					float isFrontFace = (facing >= 0 ? 1 : 0);
					float faceSign = (facing >= 0 ? 1 : -1);
					i.uv0.x +=  _Speed*_Time.x;
					float4 _Bumtex_var = tex2D(_BmpTex, TRANSFORM_TEX(i.uv0, _BmpTex));
					float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
					float node_603 = (_MainTex_var.a * _Color.a * i.vertexColor.a); // A
					float3 emissive = ((_MainTex_var.rgb * _Color.rgb * i.vertexColor.rgb) );
					float3 finalColor = emissive;
					return fixed4(finalColor,node_603);
				}
				ENDCG
			}
	   }
		   FallBack "Diffuse"
					CustomEditor "ShaderForgeMaterialInspector"
}
