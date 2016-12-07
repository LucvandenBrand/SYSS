using UnityEngine;
using System.Collections;

public class BarrelPitch : MonoBehaviour {

    public Transform CameraHolderVertical;

    private HingeJoint hingeJoint;

    void Start () {
        hingeJoint = this.GetComponent<HingeJoint>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
}
