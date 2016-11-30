using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour {
	private RenderTexture cam1Texture, cam2Texture;
	public int resolution = 128; // The resolution of the tv in pixels.
	public float curve = 0.1f; // The curvature of the screen.
	public Camera camera1;
	public Camera camera2;
	
	// Binds the camera's to the texture.
	void Start () {
		GenMesh();
		this.cam1Texture = new RenderTexture(resolution, resolution, 1);
		this.cam2Texture = new RenderTexture(resolution, resolution, 1);
		camera1.targetTexture = cam1Texture;
		camera2.targetTexture = cam2Texture;
		GetComponent<Renderer>().material.SetTexture("_MainTex", cam1Texture);
		GetComponent<Renderer>().material.SetTexture("_BlendTex", cam2Texture);
	}
	
	void GenMesh() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length) {
            vertices[i][1] += Mathf.Sin(Time.time)*(0.01f*i/vertices.Length);
            i++;
        }
        mesh.vertices = vertices;
    }
}
