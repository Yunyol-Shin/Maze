using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    [SerializeField]private GameObject map;
    [SerializeField]
    private GameObject ball;
    private Rigidbody ballbody;
    Vector3 up;
    bool unreach=false;
    public bool hard = false;
    public bool hold = false;

	// Use this for initialization
	void Start () {
        up = Vector3.up;
        ballbody = ball.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!hold)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {//-90,0,0,0
                map.transform.RotateAround(ball.transform.position, new Vector3(1, 0, 0), 90);
                ballbody.velocity = Vector3.zero;
                ballbody.angularVelocity = Vector3.zero;
                //map.transform.Rotate(90, 0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {//90,0,0,0
                map.transform.RotateAround(ball.transform.position, new Vector3(-1, 0, 0), 90);
                ballbody.velocity = Vector3.zero;
                ballbody.angularVelocity = Vector3.zero;
                // map.transform.Rotate(-90, 0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {//0,0,-90,0
                map.transform.RotateAround(ball.transform.position, new Vector3(0, 0, 1), 90);
                ballbody.velocity = Vector3.zero;
                ballbody.angularVelocity = Vector3.zero;
                //  map.transform.Rotate(0, 0, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {//0,0,90,0
                map.transform.RotateAround(ball.transform.position, new Vector3(0, 0, -1), 90);
                ballbody.velocity = Vector3.zero;
                ballbody.angularVelocity = Vector3.zero;
                //  map.transform.Rotate(0, 0, -90, 0);
            }
            else
            {
                unreach = true;
            }
            if (!unreach)
            {
                Sphere_move sm = GameObject.Find("Sphere").GetComponent<Sphere_move>();
                sm.moveable = false;
                if (hard)
                    hold = true;
            }
            unreach = false;
        }
    }
}
