Shader "Custom/DoughDeform"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DeformStrength ("Deform Strength", Range(0, 1)) = 0.2
        _DeformControl ("Deform Control", Range(-1, 1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert alpha
        
        sampler2D _MainTex;
        float _DeformStrength;
        float _DeformControl;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void vert (inout appdata_full v)
        {
            float deformFactor = _DeformControl * _DeformStrength;
            v.vertex.y += deformFactor * sin(v.vertex.x * 3.14);
            v.vertex.x += deformFactor * cos(v.vertex.z * 3.14);
        }
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 col = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = col.rgb;
            o.Alpha = col.a;
        }
        ENDCG
    }
    FallBack "Unlit/Transparent"
}
