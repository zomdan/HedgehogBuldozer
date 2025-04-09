Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" } 
        /*OG was "RenderType" = "Opaque"
         Queue bc it render last, Overlay bcs yeah
         see: https://docs.unity3d.com/Manual/SL-SubShaderTags.html */
        LOD 100

        Pass
        {
            Blend SrcAlpha One // make additive
            Cull Off // X face culling
            Lighting Off // X lighting (bcs Unlit)
            ColorMask RGB   // only affect clr channels
        /*see:  https://docs.unity3d.com/Manual/SL-Blend.html 
                https://docs.unity3d.com/Manual/SL-ZWrite.html
                

                uhhh everythings under this umbrella -> https://docs.unity3d.com/Manual/SL-Commands.html


        */
            CGPROGRAM  // no changes here
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            half4 frag (v2f i) : SV_Target //changed fixed4 to half4 ummm u can look it up. its just color output precision i guess
            {
                // sample the texture
                half4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }   Fallback "Unlit/Texture" //IMPORTANT ADD LOLZ
}
