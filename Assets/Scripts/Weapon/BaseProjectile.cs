using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Weapons
{

    [RequireComponent(typeof(Rigidbody))] 
    public class BaseProjectile : MonoBehaviour
    {
        
        [SerializeField] protected Vector3 localVelocity = Vector3.zero;
        [SerializeField] protected float maxLifetime = 120.0f;

        protected virtual void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(localVelocity);
            StartCoroutine(Lifetime());
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            DestroyProjectile();
        }

        protected virtual IEnumerator Lifetime()
        {

            float time = 0.0f;
            while(time < maxLifetime)
            {
                time += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            DestroyProjectile();

        }

        protected virtual void DestroyProjectile()
        {
            Destroy(gameObject);
        }

    }

}