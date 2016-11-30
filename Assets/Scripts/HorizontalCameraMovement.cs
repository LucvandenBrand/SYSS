using UnityEngine;
using System.Collections;

public class HorizontalCameraMovement : MonoBehaviour {
    public string horizontalViewName;
    public float horizontalViewSpeed;
	
	void LateUpdate () {
        float horizontalView = Input.GetAxis(horizontalViewName);
        this.transform.Rotate(new Vector3(0, horizontalView * horizontalViewSpeed * Time.deltaTime, 0));
    }
}
