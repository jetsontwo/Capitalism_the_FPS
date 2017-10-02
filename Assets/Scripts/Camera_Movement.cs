using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

    public float rotate_speed;
    private GameObject cam;
    private bool stop_rotate;
    private float mouse_y;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update () {
        mouse_y = -Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotate_speed, 0));
        cam.transform.Rotate(new Vector3(mouse_y * rotate_speed, 0, 0));

        if (cam.transform.localEulerAngles.x < 290 && cam.transform.localEulerAngles.x > 200)
            cam.transform.localEulerAngles = new Vector3(290, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
        else if (cam.transform.localEulerAngles.x > 30 && cam.transform.localEulerAngles.x < 100)
            cam.transform.localEulerAngles = new Vector3(30, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);

        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked);
    }
}
