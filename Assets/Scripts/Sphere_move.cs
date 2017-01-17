using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Sphere_move : MonoBehaviour {
    [SerializeField]
    GameObject goal;
    [SerializeField]
    private SphereCollider sphere_collider;
    [SerializeField]
    private GameObject map;
    private Rigidbody m_Rigidbody;
    public float resistance;
    public float speed;
    public Vector3 velocity;
    public bool dead;
    public bool moveable=true;
    private float position;
    public bool hard;
    public Vector3 lookDirection;
    Quaternion R;
    public float currentSpeed = 0f;
    
    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        R = Quaternion.LookRotation(new Vector3(1, 0, 0));
    }

    // Update is called once per frame
    void Update () {
        if (!dead && !(hard&&!moveable))
        {
            float xx = Input.GetAxisRaw("Vertical");
            float zz = Input.GetAxisRaw("Horizontal");
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
                lookDirection = xx * Vector3.forward + zz * Vector3.right;

                Quaternion Q = Quaternion.LookRotation(lookDirection);
                R = Quaternion.RotateTowards(R, Q, 10f);
                m_Rigidbody.AddForce(R.eulerAngles*speed);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!moveable)
        {
            moveable = true;
            MapController mc = map.GetComponent<MapController>();
            mc.hold = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(goal)&&!dead)
        {
            Destroy(other.gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            PlayManagerScript PM = GameObject.Find("PlayManager").GetComponent<PlayManagerScript>();
            PM.Clear();
        }
    }
}
