Shader "Custom/Television" {
	Properties 
	{
		_Curve("Curve Inverse", float) = 13
		_MainTex ("Texture", 2D) = "white" {}
		_BlendTex ("Texture", 2D) = "white" {}
	}
	 
	 
	SubShader 
	{	
		// Blend textures.
		Pass
		{
			CGPROGRAM
			// use "vert" function as the vertex shader
			#pragma vertex vert
			// use "frag" function as the pixel (fragment) shader
			#pragma fragment frag

			// vertex shader inputs
			struct appdata
			{
				float4 vertex : POSITION; // vertex position
				float2 uv : TEXCOORD0; // texture coordinate
			};

			// vertex shader outputs ("vertex to fragment")
			struct v2f
			{
				float2 uv : TEXCOORD0; // texture coordinate
				float4 vertex : SV_POSITION; // clip space position
			};

			// vertex shader
			float _Curve;

			v2f vert(appdata v)
			{
				v2f o;
				// The vertex position in view-space (camera space)
				float4 vPos = mul(UNITY_MATRIX_MV, v.vertex);
				// Get distance from camera and scale it down with the global _Dist parameter
				float xOff = vPos.x / _Curve;
				// Add the offset with a quadratic curve to the vertex position
				vPos -= .5f*xOff*xOff;

				o.vertex = mul(UNITY_MATRIX_P, vPos);
				o.uv = v.uv;
				return o;
			}

			// texture we will sample
			sampler2D _MainTex;
			sampler2D _BlendTex;

			// pixel shader; returns low precision ("fixed4" type)
			// color ("SV_Target" semantic)
			fixed4 frag (v2f i) : SV_Target
			{
				// sample texture and return it
				fixed4 col = tex2D(_MainTex, i.uv) + tex2D(_BlendTex, i.uv);
				return col;
			}
			ENDCG
		}
	} 
}
