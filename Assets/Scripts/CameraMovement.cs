using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform followObject;
    public float hoverHeight;
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(followObject.position.x, followObject.position.y + hoverHeight, followObject.position.z);
        transform.rotation = Quaternion.AngleAxis(followObject.rotation.eulerAngles.y, Vector3.up);
        //transform.rotation = followObject.rotation;
    }
}
