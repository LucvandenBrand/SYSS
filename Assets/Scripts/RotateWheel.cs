using UnityEngine;
using System.Collections;

public class RotateWheel : MonoBehaviour {

    private WheelCollider wheelCollider;
    private new Transform transform;
    
    // Use this for initialization
    void Start () {
        wheelCollider = this.GetComponent<WheelCollider>();
        transform = this.GetComponent<Transform>();
	}
	
	void FixedUpdate () {
        transform.Rotate(new Vector3(wheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0));
	}
}
