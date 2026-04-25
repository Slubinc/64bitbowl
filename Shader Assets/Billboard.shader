Shader "Custom/Billboard"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "DisableBatching" = "True" }

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            const float3 vect3Zero = float3(0.0, 0.0, 0.0);

            sampler2D _MainTex;

            v2f vert(appdata v)
            {
                v2f o;

                // object's origin in view space (object-space origin -> view space)
                float4 originView = float4(UnityObjectToViewPos(vect3Zero).xyz, 1.0);

                // transform vertex as a direction (w = 0) from object to view space.
                // using UNITY_MATRIX_MV ensures object's transform (including scale) affects the vertex offset.
                float4 viewDir = mul(UNITY_MATRIX_MV, float4(v.pos.xyz, 0.0));

                // project the final view-space position
                float4 outPos = mul(UNITY_MATRIX_P, originView + viewDir);

                o.pos = outPos;
                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}