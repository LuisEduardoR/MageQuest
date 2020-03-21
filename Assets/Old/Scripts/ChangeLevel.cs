using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MageQuest.Utility
{

    public class ChangeLevel : MonoBehaviour
    {

        [SerializeField] private string levelToLoad = "no level";

        public void Change()
        {
            
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(levelToLoad);

        }

    }

}
