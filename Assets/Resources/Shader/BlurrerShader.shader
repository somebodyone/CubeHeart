// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unity Shaders Book/Chapter 12/Gaussian Blur" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BlurSize ("Blur Size", Float) = 1.0
		_Alpha("Alpha",Float) = 10
		_Brightness("Brightness",Float) = 0
	}
	SubShader {
		
		pass{
		CGPROGRAM
		#include "UnityCG.cginc"
        #pragma vertex vert
        #pragma fragment frag
		
		sampler2D _MainTex;  
		half4 _MainTex_TexelSize;
		float _BlurSize;
		float _Alpha;
		float _Brightness;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
		};
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);			
			half2 uv = v.texcoord;
			o.uv = uv;		 
			return o;
		}
		
		fixed4 frag(v2f i) : SV_Target {
			float weight[3] = {0.4026, 0.2442, 0.0545};		
			fixed3 sum;		
			float dis;
			dis = distance(float2(0.5,0.4),i.uv[0]);
			half2 uv[5];
			uv[0] = i.uv;
			uv[1] = i.uv + float2(_MainTex_TexelSize.x * 1.0,0.0)*_BlurSize*dis;
			uv[2] = i.uv - float2( _MainTex_TexelSize.x * 1.0,0.0)*_BlurSize*dis;
			uv[3] = i.uv + float2(_MainTex_TexelSize.x * 2.0,0.0) *_BlurSize*dis;
			uv[4] = i.uv - float2(_MainTex_TexelSize.x * 2.0,0.0) *_BlurSize*dis;

			//if(dis>0){		
			sum = tex2D(_MainTex, uv[0]).rgb * weight[0];		
			for (int it = 1; it < 3; it++) {
				sum += tex2D(_MainTex, uv[it*2-1]).rgb * weight[it];
				sum += tex2D(_MainTex, uv[it*2]).rgb * weight[it];
			}
			//}
			//else
			//{
			//   sum = tex2D(_MainTex, i.uv).rgb;
			//}		
			float3 finercolor = float3(sum.r+_Brightness,sum.g+_Brightness,sum.b+_Brightness);
			return fixed4(finercolor, _Alpha);
		}		    
		ENDCG
	} 

	    pass{
		CGPROGRAM
		#include "UnityCG.cginc"
        #pragma vertex vert
        #pragma fragment frag
		
		sampler2D _MainTex;  
		half4 _MainTex_TexelSize;
		float _BlurSize;
		float _Alpha;
		float _Brightness;
		  
		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv: TEXCOORD0;
		};
		v2f vert(appdata_img v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			
			half2 uv = v.texcoord;
			o.uv = uv;		 
			return o;
		}
		
		fixed4 frag(v2f i) : SV_Target {
			float weight[3] = {0.4026, 0.2442, 0.0545};		
			fixed3 sum;		
			float dis;
			dis = distance(float2(0.5,0.4),i.uv[0]);
			half2 uv[5];
			uv[0] = i.uv;
			uv[1] = i.uv + float2(0.0, _MainTex_TexelSize.y * 1.0)*_BlurSize*dis;
			uv[2] = i.uv - float2(0.0, _MainTex_TexelSize.y * 1.0)*_BlurSize*dis;
			uv[3] = i.uv + float2(0.0, _MainTex_TexelSize.y * 2.0) *_BlurSize*dis;
			uv[4] = i.uv - float2(0.0, _MainTex_TexelSize.y * 2.0) *_BlurSize*dis;

			//if(dis>0){		
			sum = tex2D(_MainTex, uv[0]).rgb * weight[0];		
			for (int it = 1; it < 3; it++) {
				sum += tex2D(_MainTex, uv[it*2-1]).rgb * weight[it];
				sum += tex2D(_MainTex, uv[it*2]).rgb * weight[it];
			}
			//}
			//else
			//{
			//   sum = tex2D(_MainTex, i.uv).rgb;
			//}	
			float3 finercolor = float3(sum.r+_Brightness,sum.g+_Brightness,sum.b+_Brightness);
			return fixed4(finercolor, _Alpha);
		}		    
		ENDCG
	} 
}
}
