using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    public float shootPower;
    public string rTriggerName;

	// Update is called once per frame
	void Update () {
        float rTriggerValue = Input.GetAxis(rTriggerName);
        //Debug.Log("Rtrigger value " + rTriggerValue);
        if (rTriggerValue > 0.50) 
        {
            GameObject curBullit = (GameObject) Instantiate(bullet, transform.position + (transform.up), transform.rotation);
            /*Transform tf = curBullit.GetComponent<Transform>();
            tf.rotation = ownTf.rotation;
            tf.position = ownTf.position;*/
            Rigidbody rb = curBullit.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0, shootPower, 0));
        }
	}
}
