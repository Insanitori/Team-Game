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
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag != "Enemy" || other.gameObject.tag != "Ground")
        {
            Debug.Log("Not destroyed");
        }*/

        if (other.gameObject.tag == "Player")
        {
            DelayExplosion(1);
            Destroy(gameObject);
        }
    }

    IEnumerator DelayExplosion(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

    }
}
