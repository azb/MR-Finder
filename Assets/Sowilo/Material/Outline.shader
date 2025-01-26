Shader "Custom/OnlyOutlineShader"
{
    Properties
    {
        _OutlineColor("Outline Color", Color) = (1, 0, 0, 1) // �����ɫ
        _OutlineThickness("Outline Thickness", Float) = 0.02 // ��ߺ��
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Transparent" }
        LOD 100

        // ��� Pass
        Pass
        {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            Cull Front // ��Ⱦ�������Ե
            ZWrite Off // ��д����Ȼ���
            Blend SrcAlpha OneMinusSrcAlpha // ͸�����ģʽ

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

        // ��������
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

        // ���㴦��
        v2f vert(appdata_t v)
        {
            v2f o;

            // ���߷���ƫ��
            float3 worldNormal = normalize(mul((float3x3)unity_WorldToObject, v.normal));
            float4 offset = float4(worldNormal * _OutlineThickness, 0);

            // ƫ�ƺ�Ķ���λ��
            o.pos = UnityObjectToClipPos(v.vertex + offset);
            return o;
        }

        // Ƭ�δ���
        fixed4 frag(v2f i) : SV_Target
        {
            return _OutlineColor; // ��������ɫ
        }
        ENDCG
    }
    }
        FallBack "Diffuse"
}
