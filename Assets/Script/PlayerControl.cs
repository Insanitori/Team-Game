using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float speed = 10.0f;
    //private float turner = 200.0f;
    private float hInport;
    private float vInport;

    private Vector3 jup;
    private float jupin = 4.5f;
    public bool isGorunded;
    Rigidbody rb;
    
    public bool speedPowerUp;
    public bool jumpPowerUp;
    public bool shotgun;
    public bool crosshairs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jup = new Vector3(0.0f, 5.0f, 0.0f);
    

        speedPowerUp = false;
        jumpPowerUp = false;
        shotgun = true;
        crosshairs = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGorunded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Speed Powerup"))
        {
            speedPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(SpeedCountdown());
        }

        if (other.CompareTag("Jump Powerup"))
        {
            jumpPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(JumpCountdown());
        }

        if (other.CompareTag("ShotGun"))
        {
            shotgun = true;
            Destroy(other.gameObject);
            crosshairs = false;
        }
        else if (other.CompareTag("Crosshairs"))
        {
            crosshairs = true;
            Destroy(other.gameObject);
            shotgun = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        hInport = Input.GetAxis("Vertical");
        vInport = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * vInport);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * hInport);

        if (Input.GetKeyDown(KeyCode.Space) && isGorunded)
        {
            rb.AddForce(jup * jupin, ForceMode.Impulse);
            isGorunded = false;
        }

        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }

        if (transform.position.z > 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 3);
        }

        if (speedPowerUp == true)
        {
            speed = 16.0f;
        }

        if (jumpPowerUp == true)
        {
            jupin = 6.0f;
        }

    }

    IEnumerator SpeedCountdown()
    {
        yield return new WaitForSeconds(5);
        speedPowerUp = false;
        speed = 10.0f;
    }

    IEnumerator JumpCountdown()
    {
        yield return new WaitForSeconds(5);
        jumpPowerUp = false;
        jupin = 4.5f;
    }
}
