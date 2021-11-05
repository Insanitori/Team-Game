using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointdex;
    private float dist;

    private GameObject player;
    public float fast;
    private Rigidbody shootRb;

    //private bool ShootUrShot;
    private float fireRate = 1f;
    private float nextFire;

    public int curHealth = 1;
    public int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        shootRb = GetComponent<Rigidbody>();
        waypointdex = 0;
        //transform.LookAt(waypoints[waypointdex].position);

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Remember that you added a tiny game object to the player to make shoot!
        if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
        {
            //transform.LookAt(player.transform);
            if ((player.transform.position - this.transform.position).sqrMagnitude < 6 * 6)
            {
                shootRb.AddForce((player.transform.position + transform.position).normalized * fast);
                //transform.Translate(-transform.right * fast * Time.deltaTime);
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

        if (curHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Shooter Dead");
        }
    }

    void patrol()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position = (Vector3.MoveTowards(transform.position, waypoints[waypointdex].position, speed * Time.deltaTime));
    }

    void IncreaseIndex()
    {
        waypointdex++;
        if (waypointdex >= waypoints.Length)
        {
            waypointdex = 0;
        }
        //transform.LookAt(waypoints[waypointdex].position);
    }

    public void DamageEnemy(int damage)
    {
        curHealth -= damage;
    }
}
