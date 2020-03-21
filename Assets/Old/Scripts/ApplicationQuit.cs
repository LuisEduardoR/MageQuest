using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MageQuest.Utility
{

    public class ApplicationQuit : MonoBehaviour
    {

        public void Quit()
        {

            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Application.Quit();
            Debug.Log("Application.Quit()");

        }

    }

}
