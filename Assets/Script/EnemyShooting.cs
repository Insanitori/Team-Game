using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private GameObject player;
    private Rigidbody shootRb;
    public GameObject projectile;

    private float fireRate = 1f;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        shootRb = GetComponent<Rigidbody>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Remember that you added a tiny game object to the player to make shoot!
        if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
        {
            shootingTime();
        }
        
    }

    void shootingTime()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
            //Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
