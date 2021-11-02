using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 10.0f;
    //private float turner = 200.0f;
    private float hInport;
    private float vInport;

    private Vector3 jup;
    private float jupin = 4.0f;
    public bool isGorunded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jup = new Vector3(0.0f, 5.0f, 0.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGorunded = true;
    }

    // Update is called once per frame
    void Update()
    {
        hInport = Input.GetAxis("Vertical");
        vInport = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * hInport);
        //transform.Rotate(Vector3.up, turner * hInport * Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime * speed * vInport);

        if (Input.GetKeyDown(KeyCode.Space) && isGorunded)
        {
            rb.AddForce(jup * jupin, ForceMode.Impulse);
            isGorunded = false;
        }

        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }

        if (transform.position.z > 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 3);
        }
    }
}
