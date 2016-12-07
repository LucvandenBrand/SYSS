using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Television : MonoBehaviour {
	private RenderTexture cam1Texture, cam2Texture;
    private int screenX = 0, screenY = 0;
    public Camera mainCamera;
	public Camera camera1;
	public Camera camera2;

    // Rescale everything if the resolution changed.
    public void Update()
    {
        if (Screen.height != screenY || Screen.width != screenX)
        {
            this.screenX = Screen.width; this.screenY = Screen.height;
            ScaleMesh();
            BindCams();
        }
    }

    // Binds the camera's to the texture.
    void BindCams()
    {
        this.cam1Texture = new RenderTexture(screenX, screenY, 1);
        this.cam2Texture = new RenderTexture(screenX, screenY, 1);
        camera1.targetTexture = cam1Texture;
        camera2.targetTexture = cam2Texture;
        GetComponent<Renderer>().material.SetTexture("_MainTex", cam1Texture);
        GetComponent<Renderer>().material.SetTexture("_BlendTex", cam2Texture);
    }

    // Scales the mesh to perfectly fit the screen.
    void ScaleMesh()
    {
        float height = mainCamera.orthographicSize * 2.0f;
        float width = height * screenX / screenY;
        transform.localScale = new Vector3(width, height, 1);
    }
}
