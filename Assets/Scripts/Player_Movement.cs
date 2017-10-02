using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity += -transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += transform.right * speed * Time.deltaTime;
        }
        
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= speed * Time.deltaTime;
        }
    }
}
