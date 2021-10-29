using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int curHealth = 1;
    public int maxHealth = 100;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if( Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }*/

        if(curHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthbar.SetHealth(curHealth);
    }
}
