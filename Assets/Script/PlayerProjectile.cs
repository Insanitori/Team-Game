using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private zoomieEnemy destroyZoom;
    private ShootEnemy destroyShoot;
    private StabEnemy destroyStab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            destroyZoom = other.GetComponent<zoomieEnemy>();
            destroyZoom.DamageEnemy(100);
            Debug.Log("Bye Zoomie");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy2")
        {
            destroyStab = other.GetComponent<StabEnemy>();
            destroyStab.DamageEnemy(20);
            Debug.Log("Bye Stabby");
        }

        if (other.gameObject.tag == "Enemy3")
        {
            destroyShoot = other.GetComponent<ShootEnemy>();
            destroyShoot.DamageEnemy(25);
            Debug.Log("Bye Shooter");
        }
    }
}
