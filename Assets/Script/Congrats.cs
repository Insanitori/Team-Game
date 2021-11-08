using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level2");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
        }
    }
}
