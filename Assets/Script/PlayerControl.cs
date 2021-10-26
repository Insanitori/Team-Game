using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 10.0f;
    //private float turner = 200.0f;
    private float hInport;
    private float vInport;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        hInport = Input.GetAxis("Vertical");
        vInport = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * hInport);
        //transform.Rotate(Vector3.up, turner * hInport * Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime * speed * vInport);

        if (transform.position.x < -8.1)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }

        if (transform.position.z > 4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4);
        }

        if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }
}
