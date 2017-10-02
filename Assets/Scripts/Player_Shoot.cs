using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour {

    public float reload_time, bullet_speed;
    public int num_bullets;
    public GameObject bullet_spawn;

    public GameObject bullet_holder;
    private GameObject[] bullets = new GameObject[100];
    private int cur_bullet_index;

    public ParticleSystem gun_smoke;

	// Use this for initialization
	void Start () {
		foreach (Transform t in bullet_holder.transform)
        {
            bullets[cur_bullet_index++] = t.gameObject;
        }
        cur_bullet_index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(spawn_bullet());
        }
        if(Input.GetMouseButtonDown(1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, -0.13f, transform.localPosition.z), 1);
        }
        if(Input.GetMouseButtonUp(1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0.2f, -0.2f, transform.localPosition.z), 1);
        }
    }

    private IEnumerator spawn_bullet()
    {
        gun_smoke.Play();
        if (cur_bullet_index == 99)
            cur_bullet_index = 0;
        GameObject o = bullets[cur_bullet_index++];
        o.transform.position = bullet_spawn.transform.position;
        o.SetActive(true);
        o.GetComponent<Rigidbody>().velocity = transform.up * bullet_speed;
        yield return new WaitForSeconds(0f);
    }
}
