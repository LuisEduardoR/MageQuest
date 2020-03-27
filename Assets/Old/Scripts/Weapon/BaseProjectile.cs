using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Entities;

namespace MageQuest.Spells
{

    [RequireComponent(typeof(Rigidbody))] 
    public class BaseProjectile : MonoBehaviour
    {
        
        [SerializeField] protected Vector3 localVelocity = Vector3.zero;
        [SerializeField] protected float maxLifetime = 120.0f;

        [SerializeField] protected int damageAmount = 10;
        [SerializeField] protected DamageType damageType = DamageType.Normal;

        protected virtual void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(localVelocity);
            StartCoroutine(Lifetime());
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            
            BaseEntity entity = collision.collider.GetComponent<BaseEntity>();
            if(entity != null)
                entity.Damage(damageAmount, damageType);

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