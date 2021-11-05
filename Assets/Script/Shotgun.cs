using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private PlayerControl PlayerCon;

    public GameObject bouncePrefab;

    private float speed = 10.0f;
    private float hInport;
    private float vInport;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerCon.shotgun == true)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                InvokeRepeating("spawnbouncing", 0, 3.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCon.shotgun == true)
        {
            Debug.Log("It's true!");
            hInport = Input.GetAxis("Vertical2");
            vInport = Input.GetAxis("Horizontal2");

            transform.Translate(Vector3.right * Time.deltaTime * speed * vInport);
            transform.Translate(Vector3.down * Time.deltaTime * speed * hInport);

            if (transform.position.x > player.transform.position.x + 3)
            {
                transform.position = new Vector3(player.transform.position.x + 3, transform.position.y, transform.position.z);
            }

            if (transform.position.x < player.transform.position.x - 3)
            {
                transform.position = new Vector3(player.transform.position.x - 3, transform.position.y, transform.position.z);
            }

            if (transform.position.y > player.transform.position.y + 3)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y + 3, transform.position.z);
            }

            if (transform.position.y > player.transform.position.y - 1)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y - 1, transform.position.z);
            }
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z); 
        }
    }

    void spawnbouncing()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(bouncePrefab, pos, bouncePrefab.transform.rotation);
    }
}
