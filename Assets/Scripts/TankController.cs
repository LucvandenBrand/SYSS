using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankController : MonoBehaviour {
    public string horizontalMoveName;
    public string verticalMoveName;
    public float wheelPower;
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
        Debug.Log("rightTrackThrottle: " + rightTrackThrottle);

        float leftTrackThrottle = horizontalMove;
        leftTrackThrottle += verticalMove;
        if (leftTrackThrottle > 1) leftTrackThrottle = 1;
        Debug.Log("leftTrackThrottle: " + leftTrackThrottle);

        moveTrack(rightTrack, rightTrackThrottle * wheelPower * Time.deltaTime);
        moveTrack(leftTrack, leftTrackThrottle * wheelPower * Time.deltaTime);
    }

    void moveTrack(List<WheelCollider> wheelList, float power)
    {
        foreach (WheelCollider wheel in wheelList)
        {
            wheel.motorTorque = power;
        }
    }
}
