using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointAndShoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject shooter;
    public GameObject bulletP;
    public GameObject Player;
    public float bulletspeed = 60;

    private Vector2 cursorPosition;
    public float horizontalSpeed = 350.0F;
    public float verticalSpeed = 350.0F;
    public Texture2D cursorImage;
    private int cursorWidth = 100;
    private int cursorHeight = 100;

    private PlayerControl PlayerCon;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);

        PlayerCon = Player.GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCon.crosshairs == true)
        {
            shooter.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

            target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z));

            Vector3 difference = target - shooter.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            shooter.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                float distrance = difference.magnitude;
                Vector2 direction = difference / distrance;
                direction.Normalize();
                fireBullet(-direction, rotationZ);
            }
        }


    }

    void fireBullet(Vector2 direction,float rotationZ)
    {
        GameObject b = Instantiate(bulletP) as GameObject;
        b.transform.position = shooter.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody>().velocity = direction * bulletspeed;
    }

    private void OnGUI()
    {
        if (PlayerCon.crosshairs == true)
        {
            float h = horizontalSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime;
            float v = verticalSpeed * Input.GetAxis("Vertical2") * Time.deltaTime;
            cursorPosition.x += h;
            cursorPosition.y += v;

            GUI.DrawTexture(new Rect(cursorPosition.x, Screen.height - cursorPosition.y, cursorWidth, cursorHeight), cursorImage);
        }
    }

}
