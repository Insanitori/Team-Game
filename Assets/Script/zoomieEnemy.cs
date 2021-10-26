using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomieEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody zoomieRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        zoomieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        zoomieRb.AddForce((player.transform.position - transform.position).normalized * speed);
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            //while within this range, they pause for one second then explode in an AOE
        }

    }
}
