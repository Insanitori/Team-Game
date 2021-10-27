using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointAndShoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletP;

    public float bulletspeed = 60;

    private Vector2 cursorPosition;
    public float horizontalSpeed = 350.0F;
    public float verticalSpeed = 350.0F;
    public Texture2D cursorImage;
    private int cursorWidth = 100;
    private int cursorHeight = 100;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z));
        //crosshairs.transform.position = new Vector2(-target.x, (-target.y + 2));

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetKeyDown(KeyCode.K))
        {
            float distrance = difference.magnitude;
            Vector2 direction = difference / distrance;
            direction.Normalize();
            fireBullet(-direction, rotationZ);
        }
    }

    void fireBullet(Vector2 direction,float rotationZ)
    {
        GameObject b = Instantiate(bulletP) as GameObject;
        b.transform.position = player.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
    }

    private void OnGUI()
    {
        // these are not actual positions but the change between last frame and now
        float h = horizontalSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime;
        float v = verticalSpeed * Input.GetAxis("Vertical2") * Time.deltaTime;

        // add the changes to the actual cursor position
        cursorPosition.x += h;
        cursorPosition.y += v;

        GUI.DrawTexture(new Rect(cursorPosition.x, Screen.height - cursorPosition.y, cursorWidth, cursorHeight), cursorImage);
    }

}
