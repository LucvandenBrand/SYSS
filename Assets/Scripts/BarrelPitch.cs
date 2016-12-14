using UnityEngine;
using System.Collections;

public class BarrelPitch : MonoBehaviour {

    public Transform CameraHolderVertical;
    public Transform parentTransform;
    public float gunPitchSpeed;
    public float gunDepressionMin;
    public float gunDepressionMax;

    void Start () {
        //parrentTransform = GetComponentInParent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //transform.RotateAround(parentTransform.position, parentTransform.TransformDirection(Vector3.right), 20 * Time.deltaTime);

        //Debug.Log("x:y:z " + parentTransform.position);

        float current = (transform.rotation.eulerAngles.x) % 360;
        float target = (CameraHolderVertical.rotation.eulerAngles.x+90) % 360;
        Vector3 rotationDirection = parentTransform.TransformDirection(Vector3.right);

        if (target < gunDepressionMin) target = gunDepressionMin;
        if (target > gunDepressionMax) target = gunDepressionMax;

        if (CameraHolderVertical.rotation.eulerAngles.z < 90)
        {
            if (target > current + 0.5 || target < current - 0.5)
            {
                if (transform.rotation.eulerAngles.z < 90)
                {
                    if (target < current)
                    {
                        if ((current - target) < gunPitchSpeed * Time.deltaTime)
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, -(current - target) * Time.deltaTime);
                        }
                        else
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, -gunPitchSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if ((target - current) < gunPitchSpeed * Time.deltaTime)
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, (current - target) * Time.deltaTime);
                        }
                        else
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, gunPitchSpeed * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    target = 180-target;
                    if (target < current)
                    {
                        if ((current - target) < gunPitchSpeed * Time.deltaTime)
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, (current - target) * Time.deltaTime);
                        }
                        else
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, gunPitchSpeed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if ((target - current) < gunPitchSpeed * Time.deltaTime)
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, -(current - target) * Time.deltaTime);
                        }
                        else
                        {
                            transform.RotateAround(parentTransform.position, rotationDirection, -gunPitchSpeed * Time.deltaTime);
                        }
                    }
                }
            }
        }
    }
}
