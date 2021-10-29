using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomieEnemy : MonoBehaviour
{
    public float speed;
    private Rigidbody zoomieRb;
    private GameObject player;

    public int curHealth = 1;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        zoomieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        zoomieRb.AddForce((player.transform.position - transform.position).normalized * speed);

        if (curHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("Zoomer Dead");
        }
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

    public void DamageEnemy(int damage)
    {
        curHealth -= damage;
    }

    IEnumerator DelayExplosion(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

    }
}
