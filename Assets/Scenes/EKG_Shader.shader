Shader "Unlit/EKG_Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float viewAngle = 1.0;
            float speed = 3.0;
            float rate = 15.0;
            float baseamp = 0.10;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed2 p = -1 + 2 * i.uv;       // adjusting where line
                float x = _Time.w * viewAngle * speed + rate * p.x;
                float base = (2.0 + cos(x * 2.5 + _Time.w)) * (1.0 + sin(x * 3.5 + _Time.w));
                float z = frac(0.05 * x);
                z = max(z, 1.0 - z);
                z = pow(z, 20.0);

                float pulse = exp(-10000.0 * z);
                fixed4 col = fixed4(0.6, 0.7, 0.8, 1.0);
                fixed4 c = pow(clamp(1.0-abs(p.y-(baseamp*base+pulse-0.5)), 0.0, 1.0), 16.0) * col;
                return c;
            }
            ENDCG
        }
    }
}
