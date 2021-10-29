using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    private HealthPoints hurt;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag != "Enemy" || other.gameObject.tag != "Ground")
        {
            Debug.Log("Not destroyed");
        }*/

        if (other.gameObject.tag == "Player")
        {
            if ((player.transform.position - this.transform.position).sqrMagnitude < 4 * 4)
            {
                //while within this range, they pause for one second then explode in an AOE
                hurt = other.GetComponent<HealthPoints>();
                hurt.DamagePlayer(25);
                Debug.Log("Destroyed");
                Destroy(gameObject);
                
            }
        }
    }

    IEnumerator DelayExplosion(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

    }
}
