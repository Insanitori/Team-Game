using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StabEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;

    private int waypointdex;
    private float dist;

    private GameObject player;
    public float fast;
    private Rigidbody stabRb;

    private HealthPoints hurt;
    public int curHealth = 1;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        stabRb = GetComponent<Rigidbody>();
        waypointdex = 0;
        //transform.LookAt(waypoints[waypointdex].position);

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 6 * 6)
        {
            Debug.Log("Forward");
            //stabRb.AddForce((player.transform.position - transform.position).normalized * fast);
            transform.position = (Vector3.MoveTowards(transform.position, player.transform.position, fast * Time.deltaTime));
        }
        else
        {
            dist = Vector3.Distance(transform.position, waypoints[waypointdex].position);
            if (dist < 1f)
            {
                Debug.Log("Increased");
                IncreaseIndex();
            }
            patrol();
        }

        if (curHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("Stabby Dead");
        }
    }

    void patrol()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.position = (Vector3.MoveTowards(transform.position, waypoints[waypointdex].position, speed * Time.deltaTime));
        
    }

    void IncreaseIndex()
    {
        waypointdex++;
        if(waypointdex >= waypoints.Length)
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
