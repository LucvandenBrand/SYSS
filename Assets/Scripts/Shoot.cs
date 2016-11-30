using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;
    private Transform ownTf;

    void Start()
    {
        ownTf = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) 
        {
            GameObject curBullit = (GameObject) Instantiate(bullet, ownTf.position + (ownTf.forward), transform.rotation);
            /*Transform tf = curBullit.GetComponent<Transform>();
            tf.rotation = ownTf.rotation;
            tf.position = ownTf.position;*/
            Rigidbody rb = curBullit.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0, 0, 150));
        }
	}
}
