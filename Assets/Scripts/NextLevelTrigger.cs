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

                SceneManager.LoadScene(nextLevelName);

            }

        }

    }

}
