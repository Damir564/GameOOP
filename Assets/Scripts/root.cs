using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Windows;

public class root : MonoBehaviour
{

    public bool IsMain = false;
    public GameObject panel;
    bool Paused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsMain) Exit();
            else
            {
                Paused = !Paused;
                panel.SetActive(Paused);
            }
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (!IsMain)
        {
            Paused = false;
            panel.SetActive(false);
        }
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
