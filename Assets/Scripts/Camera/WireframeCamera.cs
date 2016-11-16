/* Makes the camera render in wireframe mode using the provided color and width. */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WireframeCamera : MonoBehaviour {
    public float wireWidth = 0.1f;
    public Color wireColor = Color.white;

	void Start () {
        Camera camera = GetComponent<Camera>();
        camera.SetReplacementShader(Shader.Find("Custom/Wireframe"), null);
    }
	
	// Called right before the shader renders.
	void OnPreRender () {
        Shader.SetGlobalColor("_LineColor", wireColor);
        Shader.SetGlobalFloat("_LineWidth", wireWidth);
    }
}
