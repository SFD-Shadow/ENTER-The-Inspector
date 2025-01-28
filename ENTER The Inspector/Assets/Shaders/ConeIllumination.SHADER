Shader "Custom/ConeIllumination"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _IlluminationColor ("Illumination Color", Color) = (1, 1, 0, 1)
        _ConeOrigin ("Cone Origin", Vector) = (0, 0, 0, 0)
        _ConeDirection ("Cone Direction", Vector) = (0, 0, 1, 0)
        _ConeAngle ("Cone Angle (Degrees)", Range(0, 180)) = 45
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            float4 _ConeOrigin;
            float4 _ConeDirection;
            float _ConeAngle;
            float4 _BaseColor;
            float4 _IlluminationColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                // Calculate vector from cone origin to the current fragment
                float3 toFragment = normalize(i.worldPos - _ConeOrigin.xyz);

                // Normalize cone direction
                float3 coneDirection = normalize(_ConeDirection.xyz);

                // Compute the cosine of the angle between the fragment vector and cone direction
                float dotProduct = dot(toFragment, coneDirection);

                // Compute the cosine of the cone angle
                float coneCosine = cos(radians(_ConeAngle));

                // If within the cone, use illumination color, otherwise base color
                if (dotProduct >= coneCosine)
                {
                    return _IlluminationColor;
                }
                else
                {
                    return _BaseColor;
                }
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
