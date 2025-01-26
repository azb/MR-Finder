Shader "Custom/OnlyOutlineShader"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (1, 0, 0, 1) // 描边颜色
        _OutlineThickness("Outline Thickness", Float) = 0.02 // 描边厚度
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Transparent" }
        LOD 100

        // 描边 Pass
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front // 渲染物体外边缘
            ZWrite Off // 不写入深度缓冲
            Blend SrcAlpha OneMinusSrcAlpha // 透明混合模式

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

        // 参数定义
        float4 _OutlineColor;
        float _OutlineThickness;

        struct appdata_t
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
        };

        struct v2f
        {
            float4 pos : SV_POSITION;
        };

        // 顶点处理
        v2f vert(appdata_t v)
        {
            v2f o;

            // 法线方向偏移
            float3 worldNormal = normalize(mul((float3x3)unity_WorldToObject, v.normal));
            float4 offset = float4(worldNormal * _OutlineThickness, 0);

            // 偏移后的顶点位置
            o.pos = UnityObjectToClipPos(v.vertex + offset);
            return o;
        }

        // 片段处理
        fixed4 frag(v2f i) : SV_Target
        {
            return _OutlineColor; // 输出描边颜色
        }
        ENDCG
    }
    }
        FallBack "Diffuse"
}
