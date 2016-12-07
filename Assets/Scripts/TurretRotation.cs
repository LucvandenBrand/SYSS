using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

    public Transform CameraHolderHorizontal;
    public float maxDegreesPerSecond;

    void FixedUpdate()
    {
        float current = transform.rotation.eulerAngles.y;
        float target = CameraHolderHorizontal.rotation.eulerAngles.y;

        if (target > current + 0.5 || target < current - 0.5)
        {
            if ((target - current + 360) % 360 > 180)
            {
                if (((target - current + 360) % 360) > 360 - maxDegreesPerSecond * Time.deltaTime)
                {
                    transform.Rotate(new Vector3(0, -((target - current + 360) % 360), 0));
                }
                else
                {
                    transform.Rotate(new Vector3(0, -maxDegreesPerSecond * Time.deltaTime, 0));
                }
            }
            else
            {
                if (((target - current + 360) % 360) < maxDegreesPerSecond * Time.deltaTime)
                {
                    transform.Rotate(new Vector3(0, ((target - current + 360) % 360), 0));
                }
                else
                {
                    transform.Rotate(new Vector3(0, maxDegreesPerSecond * Time.deltaTime, 0));
                }
            }
        }
    }
}
