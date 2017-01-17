using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private float up;
    private float magnitude;
    private Sphere_move sphere;
	// Use this for initialization

	void Start ()
    {
        offset = transform.position - player.transform.position;
        up = offset.y;
        magnitude = new Vector2(offset.x, offset.z).magnitude;
        sphere = player.GetComponent<Sphere_move>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 moving_direction = sphere.velocity;
        if (sphere.speed != 0)
            moving_direction = moving_direction / sphere.speed;
        offset = new Vector3(moving_direction.x, -0.05f, moving_direction.z);
        offset= offset/offset.magnitude*magnitude;
        transform.position = player.transform.position - offset;
        transform.LookAt(sphere.transform);
    }



}
