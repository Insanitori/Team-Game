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
    public GameObject projectile;

    private bool ShootUrShot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        shootRb = GetComponent<Rigidbody>();
        waypointdex = 0;
        transform.LookAt(waypoints[waypointdex].position);
        //StartCoroutine(Shooting());
        //InvokeRepeating("shooting", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Shooting());

        //Remember that you added a tiny game object to the player to make shoot!
        if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
        {
            //Instantiate(projectile, transform.position, projectile.transform.rotation);
            
            transform.LookAt(player.transform);
            ShootUrShot = true;
            
            if ((player.transform.position - this.transform.position).sqrMagnitude < 6 * 6)
            {
                shootRb.AddForce((player.transform.position + transform.position).normalized * fast);
            }
        }
        else
        {
            ShootUrShot = false;
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

    /*IEnumerator Shooting(float t)
    {
        while (ShootUrShot == true)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            yield return new WaitForSeconds(10f);
        }
        
    }
    */

    void shooting()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
