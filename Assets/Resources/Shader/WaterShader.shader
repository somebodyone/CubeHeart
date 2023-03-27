﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/WaterShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color",Color) = (1,1,1,1)
		_Magnitude("Magnitude",Float) = 1
		_Frequency("Frequency",Float) = 1
		_InvWaveLength("InvWaveLength",Float) = 10
		_Speed("Speed",Float) = 0.5
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" "IgnoreProjector" = "True" "DisableBatching" = "True"}
		LOD 100

		Pass
		{
		    Tags{"LightMode" = "ForwardBase"}
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _Magnitude;
			float _Frequency;
			float _InvWaveLength;
			float _Speed;

			v2f vert (appdata_full v)
			{
				v2f o;
				float4 offset;
				offset.yzw = float3(0,0,0);
				offset.x = sin(_Frequency*_Time.y+v.vertex.x*_InvWaveLength+v.vertex.y*_InvWaveLength+v.vertex.z * _InvWaveLength)*_Magnitude;
				o.vertex = UnityObjectToClipPos(v.vertex+offset);
				o.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
				o.uv+=float2(0,_Time.y*_Speed);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb*=_Color.rgb;
				return col;
			}
			ENDCG
		}
	}
}
