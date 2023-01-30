Shader "Unlit/VertexMovement"
{
    Properties
    {
        _Speed("Speed", float) = 100
        _BlendingSpeed("Blending Speed", float) = 100
        _VerticalOffset("Horizontal Offset", Range(0,1)) = 0.5
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture2D", 2D) = "white" {}
        _SecTex("Texture2D", 2D) = "white" {}
        _Blend("Blend", Range(0,1)) = 0.5
        distance("distance", float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
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

            float _Speed;
            float _VerticalOffset;
            half4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _SecTex;
            float4 _SecTex_ST;
            float _Blend;
            float _BlendingSpeed;
            float distance;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                _VerticalOffset = sin(_Time * _Speed);
                o.vertex.y += _VerticalOffset * distance;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                _Blend = sin(_Time * _BlendingSpeed);
                fixed4 col = lerp(tex2D(_MainTex,i.uv), tex2D(_SecTex,i.uv), _Blend);
                col *= _Color;
                return col;
            }
            ENDCG
        }
    }
}
