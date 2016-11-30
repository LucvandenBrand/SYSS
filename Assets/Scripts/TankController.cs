using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TankController : MonoBehaviour {
    public string horizontalMoveName;
    public string verticalMoveName;
    public float wheelPower;
    public float brakePower;
    public List<WheelCollider> rightTrack;
    public List<WheelCollider> leftTrack;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontalMove = Input.GetAxis(horizontalMoveName);
        float verticalMove = Input.GetAxis(verticalMoveName);

        float rightTrackThrottle = -horizontalMove;
        rightTrackThrottle += verticalMove;
        if (rightTrackThrottle > 1) rightTrackThrottle = 1;
        if (rightTrackThrottle < -11) rightTrackThrottle = -1;
        //Debug.Log("rightTrackThrottle: " + rightTrackThrottle);

        float leftTrackThrottle = horizontalMove;
        leftTrackThrottle += verticalMove;
        if (leftTrackThrottle > 1) leftTrackThrottle = 1;
        if (leftTrackThrottle < -1) leftTrackThrottle = -1;
        //Debug.Log("leftTrackThrottle: " + leftTrackThrottle);

        moveTrack(rightTrack, rightTrackThrottle * wheelPower * Time.deltaTime);
        moveTrack(leftTrack, leftTrackThrottle * wheelPower * Time.deltaTime);
    }

    void moveTrack(List<WheelCollider> wheelList, float power)
    {
        foreach (WheelCollider wheel in wheelList)
        {
            //check if direction reversed, and therefore has to break or power.
            if (Math.Abs(wheel.rpm) < 1 || (Math.Sign(wheel.rpm) == Math.Sign(power)))
            {
                wheel.brakeTorque = 0;
                wheel.motorTorque = power;
                //Debug.Log("POWERRR " + wheel.motorTorque + " " + wheel.brakeTorque);
            }
            else
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = brakePower * Time.deltaTime;
                //Debug.Log("BRAKKKEEE " + wheel.motorTorque + " " + wheel.brakeTorque);
            }
        }
    }
}
