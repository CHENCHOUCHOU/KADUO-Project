// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33833,y:32364,varname:node_9361,prsc:2|custl-5319-OUT,olwid-6052-OUT,olcol-5737-RGB;n:type:ShaderForge.SFN_LightVector,id:1197,x:30820,y:33091,varname:node_1197,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2825,x:31145,y:32347,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:2976,x:31562,y:32252,varname:node_2976,prsc:2,dt:1|A-8410-OUT,B-1197-OUT;n:type:ShaderForge.SFN_Append,id:4658,x:32371,y:32512,varname:node_4658,prsc:2|A-9351-OUT,B-9351-OUT;n:type:ShaderForge.SFN_Tex2d,id:3690,x:32555,y:32512,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_3690,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:783744d51454f6a46a10d226839b2d8e,ntxv:0,isnm:False|UVIN-4658-OUT;n:type:ShaderForge.SFN_Slider,id:6052,x:33241,y:32849,ptovrint:False,ptlb:Outline Width,ptin:_OutlineWidth,varname:node_6052,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.05;n:type:ShaderForge.SFN_Color,id:5737,x:33398,y:32943,ptovrint:False,ptlb:Outline Color,ptin:_OutlineColor,varname:node_5737,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_LightAttenuation,id:146,x:31495,y:31993,varname:node_146,prsc:2;n:type:ShaderForge.SFN_LightColor,id:8323,x:32901,y:33103,varname:node_8323,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:1388,x:32911,y:32484,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4299,x:33148,y:32569,varname:node_4299,prsc:2|A-1388-RGB,B-3117-OUT,C-6731-OUT;n:type:ShaderForge.SFN_Fresnel,id:7933,x:32638,y:32086,varname:node_7933,prsc:2|EXP-3287-OUT;n:type:ShaderForge.SFN_Step,id:9385,x:32818,y:32045,varname:node_9385,prsc:2|A-9622-OUT,B-7933-OUT;n:type:ShaderForge.SFN_Slider,id:7539,x:32107,y:32107,ptovrint:False,ptlb:Fresnel Width,ptin:_FresnelWidth,varname:node_7539,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:7.765117,max:10;n:type:ShaderForge.SFN_Add,id:5319,x:33463,y:32555,varname:node_5319,prsc:2|A-7585-OUT,B-4299-OUT,C-9927-OUT;n:type:ShaderForge.SFN_Multiply,id:7858,x:31772,y:32218,varname:node_7858,prsc:2|A-8180-OUT,B-2976-OUT;n:type:ShaderForge.SFN_Power,id:3117,x:32789,y:32674,varname:node_3117,prsc:2|VAL-3690-RGB,EXP-7882-OUT;n:type:ShaderForge.SFN_Slider,id:7882,x:32424,y:32728,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_7882,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_ViewReflectionVector,id:9552,x:30820,y:33275,varname:node_9552,prsc:2;n:type:ShaderForge.SFN_Dot,id:3537,x:31059,y:33115,varname:node_3537,prsc:2,dt:1|A-1197-OUT,B-9552-OUT;n:type:ShaderForge.SFN_Power,id:8100,x:31300,y:33085,varname:node_8100,prsc:2|VAL-3537-OUT,EXP-6102-OUT;n:type:ShaderForge.SFN_Slider,id:6102,x:30948,y:33328,ptovrint:False,ptlb:3S Width,ptin:_3SWidth,varname:node_6102,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:4.729785,max:10;n:type:ShaderForge.SFN_Multiply,id:1728,x:31528,y:33085,varname:node_1728,prsc:2|A-8100-OUT,B-4702-OUT;n:type:ShaderForge.SFN_Slider,id:4702,x:31289,y:33322,ptovrint:False,ptlb:3S Light,ptin:_3SLight,varname:node_4702,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.139112,max:2;n:type:ShaderForge.SFN_Add,id:9351,x:32166,y:32512,varname:node_9351,prsc:2|A-7858-OUT,B-2380-OUT;n:type:ShaderForge.SFN_Tex2d,id:5597,x:31145,y:32137,ptovrint:False,ptlb:Nomal,ptin:_Nomal,varname:node_5597,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:8410,x:31384,y:32182,varname:node_8410,prsc:2|A-5597-RGB,B-2825-OUT;n:type:ShaderForge.SFN_Color,id:9569,x:32818,y:31844,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:node_9569,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3024,x:33026,y:32071,varname:node_3024,prsc:2|A-9569-RGB,B-9385-OUT,C-7789-OUT;n:type:ShaderForge.SFN_Vector1,id:7789,x:32818,y:32208,varname:node_7789,prsc:2,v1:2;n:type:ShaderForge.SFN_SwitchProperty,id:2380,x:31734,y:32972,ptovrint:False,ptlb:3S,ptin:_3S,varname:node_2380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-9714-OUT,B-1728-OUT;n:type:ShaderForge.SFN_Vector1,id:9714,x:31528,y:32972,varname:node_9714,prsc:2,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:7585,x:33192,y:32028,ptovrint:False,ptlb:Fresnel,ptin:_Fresnel,varname:node_7585,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-3536-OUT,B-3024-OUT;n:type:ShaderForge.SFN_Vector1,id:3536,x:33002,y:31970,varname:node_3536,prsc:2,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:6731,x:33043,y:32965,ptovrint:False,ptlb:Light Color,ptin:_LightColor,varname:node_6731,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-2863-OUT,B-8323-RGB;n:type:ShaderForge.SFN_Vector1,id:2863,x:32838,y:32999,varname:node_2863,prsc:2,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:8180,x:31666,y:31937,ptovrint:False,ptlb:Lighting Attenuation,ptin:_LightingAttenuation,varname:node_8180,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4804-OUT,B-146-OUT;n:type:ShaderForge.SFN_Vector1,id:4804,x:31495,y:31888,varname:node_4804,prsc:2,v1:1;n:type:ShaderForge.SFN_HalfVector,id:9119,x:31138,y:32568,varname:node_9119,prsc:2;n:type:ShaderForge.SFN_Dot,id:2932,x:31412,y:32600,varname:node_2932,prsc:2,dt:1|A-2825-OUT,B-9119-OUT;n:type:ShaderForge.SFN_Power,id:6789,x:31689,y:32593,varname:node_6789,prsc:2|VAL-2932-OUT,EXP-1401-OUT;n:type:ShaderForge.SFN_Exp,id:1401,x:31497,y:32754,varname:node_1401,prsc:2,et:1|IN-8252-OUT;n:type:ShaderForge.SFN_Slider,id:8093,x:30981,y:32775,ptovrint:False,ptlb:Specular Range,ptin:_SpecularRange,varname:node_8093,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.548824,max:10;n:type:ShaderForge.SFN_Multiply,id:1651,x:32155,y:32712,varname:node_1651,prsc:2|A-7392-RGB,B-7664-OUT,C-8095-OUT,D-8323-RGB;n:type:ShaderForge.SFN_Slider,id:8095,x:31646,y:32859,ptovrint:False,ptlb:Specular Intensity,ptin:_SpecularIntensity,varname:_SpecularRange_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.501,max:5;n:type:ShaderForge.SFN_SwitchProperty,id:9927,x:32957,y:32796,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_9927,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4668-OUT,B-1651-OUT;n:type:ShaderForge.SFN_Vector1,id:4668,x:32734,y:32796,varname:node_4668,prsc:2,v1:0;n:type:ShaderForge.SFN_Step,id:7664,x:31908,y:32657,varname:node_7664,prsc:2|A-5406-OUT,B-6789-OUT;n:type:ShaderForge.SFN_Vector1,id:5406,x:31758,y:32758,varname:node_5406,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:7392,x:31835,y:32438,ptovrint:False,ptlb:Specular Color,ptin:_SpecularColor,varname:node_7392,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_RemapRange,id:8252,x:31311,y:32754,varname:node_8252,prsc:2,frmn:0,frmx:10,tomn:10,tomx:0|IN-8093-OUT;n:type:ShaderForge.SFN_RemapRange,id:3287,x:32345,y:32213,varname:node_3287,prsc:2,frmn:0,frmx:10,tomn:10,tomx:0|IN-7539-OUT;n:type:ShaderForge.SFN_Slider,id:2812,x:32130,y:31938,ptovrint:False,ptlb:Fresnel N,ptin:_FresnelN,varname:node_2812,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5606992,max:1.1;n:type:ShaderForge.SFN_RemapRange,id:9622,x:32491,y:31870,varname:node_9622,prsc:2,frmn:0,frmx:1.1,tomn:1.1,tomx:0|IN-2812-OUT;proporder:6052-5737-3690-1388-5597-7585-9569-7539-2812-6731-8180-2380-6102-4702-7882-9927-7392-8093-8095;pass:END;sub:END;*/

Shader "Shader Forge/Duse_Catoon_02" {
    Properties {
        _OutlineWidth ("Outline Width", Range(0, 0.05)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Ramp ("Ramp", 2D) = "white" {}
        _Texture ("Texture", 2D) = "white" {}
        _Nomal ("Nomal", 2D) = "bump" {}
        [MaterialToggle] _Fresnel ("Fresnel", Float ) = 1
        [HDR]_FresnelColor ("Fresnel Color", Color) = (0.5,0.5,0.5,1)
        _FresnelWidth ("Fresnel Width", Range(0, 10)) = 7.765117
        _FresnelN ("Fresnel N", Range(0, 1.1)) = 0.5606992
        [MaterialToggle] _LightColor ("Light Color", Float ) = 0
        [MaterialToggle] _LightingAttenuation ("Lighting Attenuation", Float ) = 0
        [MaterialToggle] _3S ("3S", Float ) = 0
        _3SWidth ("3S Width", Range(0.1, 10)) = 4.729785
        _3SLight ("3S Light", Range(0, 2)) = 1.139112
        _Power ("Power", Range(0, 10)) = 2
        [MaterialToggle] _Specular ("Specular", Float ) = 0
        [HDR]_SpecularColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
        _SpecularRange ("Specular Range", Range(0, 10)) = 8.548824
        _SpecularIntensity ("Specular Intensity", Range(0, 5)) = 3.501
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform float _OutlineWidth;
            uniform float4 _OutlineColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_OutlineWidth,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_OutlineColor.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _FresnelWidth;
            uniform float _Power;
            uniform float _3SWidth;
            uniform float _3SLight;
            uniform sampler2D _Nomal; uniform float4 _Nomal_ST;
            uniform float4 _FresnelColor;
            uniform fixed _3S;
            uniform fixed _Fresnel;
            uniform fixed _LightColor;
            uniform fixed _LightingAttenuation;
            uniform float _SpecularRange;
            uniform float _SpecularIntensity;
            uniform fixed _Specular;
            uniform float4 _SpecularColor;
            uniform float _FresnelN;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 _Nomal_var = UnpackNormal(tex2D(_Nomal,TRANSFORM_TEX(i.uv0, _Nomal)));
                float node_9351 = ((lerp( 1.0, attenuation, _LightingAttenuation )*max(0,dot((_Nomal_var.rgb*i.normalDir),lightDirection)))+lerp( 0.0, (pow(max(0,dot(lightDirection,viewReflectDirection)),_3SWidth)*_3SLight), _3S ));
                float2 node_4658 = float2(node_9351,node_9351);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4658, _Ramp));
                float3 finalColor = (lerp( 0.0, (_FresnelColor.rgb*step((_FresnelN*-1.0+1.1),pow(1.0-max(0,dot(normalDirection, viewDirection)),(_FresnelWidth*-1.0+10.0)))*2.0), _Fresnel )+(_Texture_var.rgb*pow(_Ramp_var.rgb,_Power)*lerp( 1.0, _LightColor0.rgb, _LightColor ))+lerp( 0.0, (_SpecularColor.rgb*step(0.5,pow(max(0,dot(i.normalDir,halfDirection)),exp2((_SpecularRange*-1.0+10.0))))*_SpecularIntensity*_LightColor0.rgb), _Specular ));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _FresnelWidth;
            uniform float _Power;
            uniform float _3SWidth;
            uniform float _3SLight;
            uniform sampler2D _Nomal; uniform float4 _Nomal_ST;
            uniform float4 _FresnelColor;
            uniform fixed _3S;
            uniform fixed _Fresnel;
            uniform fixed _LightColor;
            uniform fixed _LightingAttenuation;
            uniform float _SpecularRange;
            uniform float _SpecularIntensity;
            uniform fixed _Specular;
            uniform float4 _SpecularColor;
            uniform float _FresnelN;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));
                float3 _Nomal_var = UnpackNormal(tex2D(_Nomal,TRANSFORM_TEX(i.uv0, _Nomal)));
                float node_9351 = ((lerp( 1.0, attenuation, _LightingAttenuation )*max(0,dot((_Nomal_var.rgb*i.normalDir),lightDirection)))+lerp( 0.0, (pow(max(0,dot(lightDirection,viewReflectDirection)),_3SWidth)*_3SLight), _3S ));
                float2 node_4658 = float2(node_9351,node_9351);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4658, _Ramp));
                float3 finalColor = (lerp( 0.0, (_FresnelColor.rgb*step((_FresnelN*-1.0+1.1),pow(1.0-max(0,dot(normalDirection, viewDirection)),(_FresnelWidth*-1.0+10.0)))*2.0), _Fresnel )+(_Texture_var.rgb*pow(_Ramp_var.rgb,_Power)*lerp( 1.0, _LightColor0.rgb, _LightColor ))+lerp( 0.0, (_SpecularColor.rgb*step(0.5,pow(max(0,dot(i.normalDir,halfDirection)),exp2((_SpecularRange*-1.0+10.0))))*_SpecularIntensity*_LightColor0.rgb), _Specular ));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
