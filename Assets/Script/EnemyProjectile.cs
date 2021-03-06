using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{
    //public Image healthbar;
    public float fly;
    private Vector2 moveDirect;
    private Rigidbody rb;
    private PlayerControl player;
    private HealthPoints hurt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerControl>();
        rb = GetComponent<Rigidbody>();
        moveDirect = (player.transform.position - transform.position).normalized * fly;
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * fly);
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
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}
