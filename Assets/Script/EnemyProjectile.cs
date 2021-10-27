using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{
    public Image healthbar;
    public float fly = 10.0f;
    //public GameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * fly);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy" || other.gameObject.tag != "Ground")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "player")
        {
            Destroy(healthbar);
        }
    }
}
