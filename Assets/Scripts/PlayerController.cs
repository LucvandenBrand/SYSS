using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;

    public string moveKeysName;
    public string rotateKeysName;
    public float moveSpeed;
    public float rotationSpeed;

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
        float moveVertical = Input.GetAxis(moveKeysName);

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical * moveSpeed * Time.deltaTime);
        rb.AddRelativeForce(movement);
    }

    /*Manages all the rotation*/
    private void RotateAction()
    {
        float moveHorizontal = Input.GetAxis(rotateKeysName);
        Vector3 rotation = new Vector3(0.0f, moveHorizontal * rotationSpeed, 0.0f);
        rb.AddRelativeTorque(rotation * Time.deltaTime);
    }
}
