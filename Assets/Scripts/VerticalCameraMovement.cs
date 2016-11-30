using UnityEngine;
using System.Collections;

public class VerticalCameraMovement : MonoBehaviour {
    public string verticalViewName;
    public float verticalViewSpeed;

    void LateUpdate()
    {
        float verticalView = Input.GetAxis(verticalViewName);
        this.transform.Rotate(new Vector3(verticalView * verticalViewSpeed * Time.deltaTime, 0, 0));
    }
}
