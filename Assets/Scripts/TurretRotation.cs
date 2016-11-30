using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

    public GameObject goTarget;
    public float maxDegreesPerSecond;
    private Quaternion qTo;
    ConfigurableJoint cj;


    void Start()
    {
        cj = this.GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        /*cj.angularYZDrive = 
        Vector3 v3T = goTarget.transform.position - transform.position;
        v3T.y = transform.position.y;
        qTo = Quaternion.LookRotation(v3T, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, maxDegreesPerSecond * Time.deltaTime);*/
    }
}
