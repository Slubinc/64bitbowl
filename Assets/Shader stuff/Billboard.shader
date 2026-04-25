Shader "Custom/Billboard"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Size ("Intensity", Float) = 1.0
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

            Float _Size;

            v2f vert(appdata v)
            {
                v2f o;

                // Get object center in view space
                float3 center = UnityObjectToViewPos(float3(0,0,0));

                // Offset each vertex (quad) by its local position, scaled by _Size
                float3 offset = float3(v.pos.x, v.pos.y, 0) * _Size;

                // Final position in view space
                float3 viewPos = center + offset;

                // Project to clip space
                o.pos = mul(UNITY_MATRIX_P, float4(viewPos, 1.0));
                o.uv = v.uv;

    return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Don't need to do anything special, just render the texture
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}