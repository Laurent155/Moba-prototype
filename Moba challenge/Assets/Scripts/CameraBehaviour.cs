using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 12f, -10f);
    private Transform target;
    private float camFOV;
    public float zoomSpeed;
    private Camera cam;
    private float mouseScroll;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // this moves the camera smoothly when the player moves, with an offset
        Vector3 pos = target.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, pos, 0.5f);

        // this controls the zooming of the camera with mouse scroll
        // using GetAxis to get 1 or -1 (direction), and scale it with zoom speed
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        camFOV -= mouseScroll * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30, 60);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpeed);
    }
}
