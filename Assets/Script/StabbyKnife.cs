using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabbyKnife : MonoBehaviour
{
    private HealthPoints hurt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy" || other.gameObject.tag != "Ground")
        {
            Debug.Log("Not destroyed");
        }

        if (other.gameObject.tag == "Player")
        {
            hurt = other.GetComponent<HealthPoints>();
            hurt.DamagePlayer(5);
            Debug.Log("Destroyed");
        }
    }
}
