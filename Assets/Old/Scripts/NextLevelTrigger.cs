using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MageQuest.Utility
{

    public class NextLevelTrigger : MonoBehaviour
    {

        [SerializeField] private string nextLevelName = "no level";

        void OnTriggerEnter(Collider other)
        {

            if(other.tag == "Player")
            {

                Time.timeScale = 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(nextLevelName);

            }

        }

    }

}
