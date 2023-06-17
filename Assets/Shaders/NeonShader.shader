Shader "Custom/NeonShader"
{
    Properties
    {
        _Color("Main Color", Color) = (0,1,0,1)
        _Emission("Emission", Range(0, 5)) = 1
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

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            uniform float _Emission;
            uniform float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = _Color;
                col.rgb *= _Emission;
                return col;
            }
            ENDCG
        }
    }
}
