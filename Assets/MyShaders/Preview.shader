// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Preview" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _Noise ("Noise", 2D) = "black" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _EmissionColor ("Emission Color", Color) = (0,0.9409962,1,1)
        _EmissonAmount ("Emisson Amount", Range(0, 4)) = 4
        _TextureSpeed ("Texture Speed", Range(1, 10)) = 7
        [MaterialToggle] _RampMoves ("Ramp Moves", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _EmissionColor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _EmissonAmount;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _TextureSpeed;
            uniform fixed _RampMoves;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_7243 = _Time + _TimeEditor;
                float node_3684 = (_TextureSpeed*-1.11+11.11);
                float node_7317 = (node_7243.g/node_3684);
                float2 node_1655 = (i.uv0+node_7317*float2(1,1));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1655, _Texture));
                clip(_Texture_var.g - 0.5);
////// Lighting:
////// Emissive:
                float2 node_675 = (i.uv0+(node_3684*node_7317*_RampMoves)*float2(1,1));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_675, _Noise));
                float2 node_9743 = float2(_Noise_var.r,0.0);
                float4 node_8227 = tex2D(_Ramp,TRANSFORM_TEX(node_9743, _Ramp));
                float3 emissive = (node_8227.rgb+(_EmissionColor.rgb*_Texture_var.r*_EmissonAmount));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _TextureSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_7243 = _Time + _TimeEditor;
                float node_3684 = (_TextureSpeed*-1.11+11.11);
                float node_7317 = (node_7243.g/node_3684);
                float2 node_1655 = (i.uv0+node_7317*float2(1,1));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_1655, _Texture));
                clip(_Texture_var.g - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}