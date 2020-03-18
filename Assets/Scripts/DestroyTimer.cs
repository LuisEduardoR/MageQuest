using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Utility
{

    public class DestroyTimer : MonoBehaviour
    {

        [SerializeField] private float timeToDestroy = 5.0f;

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {

            float time = 0.0f;
            while(time < timeToDestroy)
            {
                time += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            Destroy(gameObject);

        }

    }

}
