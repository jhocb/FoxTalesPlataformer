Shader "CustomRenderTexture/ShadowMask" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _ShadowMask ("Shadow Mask", 2D) = "white" { }
    }
    SubShader {
        Tags { "RenderType"="UniversalForward" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _ShadowMask;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
            
            // Use o valor do mapa de alpha como máscara de sombra
            o.Alpha = tex2D(_ShadowMask, IN.uv_MainTex).r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
