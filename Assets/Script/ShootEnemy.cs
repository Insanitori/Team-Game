using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointdex;
    private float dist;

    private GameObject player;
    public float fast;
    private Rigidbody shootRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        shootRb = GetComponent<Rigidbody>();
        waypointdex = 0;
        transform.LookAt(waypoints[waypointdex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
        {
            //this is where they stop and shoot!
            if ((player.transform.position - this.transform.position).sqrMagnitude < 6 * 6)
            {
                shootRb.AddForce((player.transform.position + transform.position).normalized * fast);
            }
        }
        else
        {
            dist = Vector3.Distance(transform.position, waypoints[waypointdex].position);
            if (dist < 1f)
            {
                IncreaseIndex();
            }
            patrol();
        }
    }

    void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointdex++;
        if (waypointdex >= waypoints.Length)
        {
            waypointdex = 0;
        }
        transform.LookAt(waypoints[waypointdex].position);
    }
}
