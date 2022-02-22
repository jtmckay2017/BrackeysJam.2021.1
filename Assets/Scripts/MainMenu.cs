using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlayground()
    {
        GameManager.Instance.isTimedMode = false;
        SceneManager.LoadScene(1);
    }

    public void StartChap()
    {
        GameManager.Instance.isTimedMode = false;
        SceneManager.LoadScene(2);
    }

    public void StartJohn()
    {
        GameManager.Instance.isTimedMode = false;
        SceneManager.LoadScene(3);
    }


    public void QuitApplication()
    {
        Application.Quit();
    }
}
