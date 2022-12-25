Shader "Example/Slices" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _Distance ("SliceDistance", float) = 5
      _ClipDis ("ClipOutDistance", float) = 0.5
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 worldPos;

      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      half _Distance;
      half _ClipDis;

      void surf (Input IN, inout SurfaceOutput o) {
          clip (frac((IN.worldPos.x * 0.1 +IN.worldPos.z)*(IN.worldPos.x + IN.worldPos.z * 0.1) * _Distance) - _ClipDis);
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }