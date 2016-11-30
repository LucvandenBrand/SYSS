using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private Rigidbody rb;

    public string xKeysName;
    public string yKeysName;
    public string zKeysName;
    public string throtleKeyName;
    public float xSpeed;
    public float ySpeed;
    public float zSpeed;
    public float acceleration;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Only allow rotation in the y rotation
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    /*Manages the movement and rotation of the player*/
    void FixedUpdate()
    {
        RotateAction();
        MoveAction();
    }

    /*Manages the forward and backward movement*/
    private void MoveAction()
    {
        float throtleValue = Input.GetAxis(throtleKeyName);

        Vector3 movement = new Vector3(0.0f, 0.0f, throtleValue * acceleration * Time.deltaTime);
        rb.AddRelativeForce(movement);
    }

    /*Manages all the rotation*/
    private void RotateAction()
    {
        float xKeysValue = Input.GetAxis(xKeysName);
        float yKeysValue = Input.GetAxis(yKeysName);
        float zKeysValue = Input.GetAxis(zKeysName);
        Vector3 rotation = new Vector3(xKeysValue * xSpeed, yKeysValue * ySpeed, zKeysValue * zSpeed);
        rb.AddRelativeTorque(rotation * Time.deltaTime);
    }
}
