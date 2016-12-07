using UnityEngine;
using System.Collections;

public class BarrelPitch : MonoBehaviour {

    public Transform CameraHolderVertical;

    private HingeJoint hingeJoint;

    void Start () {
        hingeJoint = GetComponent<HingeJoint>();
        JointMotor motor = hingeJoint.motor;
        motor.force = 100;
        motor.targetVelocity = 90;
        motor.freeSpin = false;
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //hingeJoint.motor.force
	}
}
