using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public float lifetime;
    private float cur_lifetime;

    void OnEnable()
    {
        cur_lifetime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        cur_lifetime += Time.deltaTime;
        if (cur_lifetime > lifetime)
            gameObject.SetActive(false);
	}
}
