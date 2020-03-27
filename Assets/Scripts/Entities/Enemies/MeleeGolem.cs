using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Entities
{

    public class MeleeGolem : BaseGolem
    {

        [SerializeField] protected float attackDelay = 1.0f;
        [SerializeField] protected Vector3 attackBoxOffset = Vector3.zero;
        [SerializeField] protected Vector3 attackBoxSize = Vector3.one;

        [SerializeField] protected LayerMask attackMask = new LayerMask();

        [SerializeField] protected int damageAmount = 10;
        [SerializeField] protected DamageType damageType = DamageType.Normal;

        protected override IEnumerator PerformAttack()
        {
            // Waits for the delay.
            float timer = 0.0f;
            while(timer < attackDelay)
            {

                if(currentState == EnemyState.Dead)
                    break;

                yield return new WaitForFixedUpdate();
                timer += Time.fixedDeltaTime;
            }


            if(currentState != EnemyState.Dead)
            {

                // Checks for a hit.
                RaycastHit hit;
                if(Physics.BoxCast(transform.position + attackBoxOffset - (transform.forward * 5.0f), attackBoxSize / 2.0f, transform.forward, out hit, transform.rotation, 7.0f + attackDistance))
                {
                    PlayerEntity player = hit.transform.GetComponent<PlayerEntity>();
                    if(player != null) 
                        player.Damage(damageAmount, damageType);
                }

            }

        }

        protected virtual void OnDrawGizmos()
        {
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + attackBoxOffset, attackBoxSize);
            Gizmos.DrawRay(transform.position, transform.forward * (attackDistance));

        }

    }

}