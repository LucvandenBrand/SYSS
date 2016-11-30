using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Television : MonoBehaviour {
	private RenderTexture cam1Texture, cam2Texture;
	public int resolutionX = 1920; // The resolution width of the tv in pixels.
    public int resolutionY = 1080; // The resolution height of the tv in pixels.
    public float curve = 0.1f; // The curvature of the screen.
	public Camera camera1;
	public Camera camera2;
	
	// Binds the camera's to the texture.
	void Start () {
		GenMesh();
		this.cam1Texture = new RenderTexture(resolutionX, resolutionY, 1);
		this.cam2Texture = new RenderTexture(resolutionX, resolutionY, 1);
		camera1.targetTexture = cam1Texture;
		camera2.targetTexture = cam2Texture;
		GetComponent<Renderer>().material.SetTexture("_MainTex", cam1Texture);
		GetComponent<Renderer>().material.SetTexture("_BlendTex", cam2Texture);
	}
	
	void GenMesh() {
        float scale = 1;
        float scaleX = scale*resolutionX/resolutionY;
        transform.localScale = new Vector3(scaleX, 1, scale);
    }
}
