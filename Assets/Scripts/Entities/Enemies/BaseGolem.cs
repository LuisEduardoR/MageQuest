using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MageQuest.Entities
{

    public abstract class BaseGolem : BaseEnemy
    {

        [SerializeField] protected float followDistance = 15.0f;
        [SerializeField] protected float attackDistance = 1.0f;

        private float updatePathTimer = 0.25f;
        private bool attacking = false;

        Animator animator;
        AudioSource audioSource;

        [SerializeField] protected AudioClip damageAudio = null;
        [SerializeField] protected AudioClip attackAudio = null;

        protected override void Start()
        {

            animator = GetComponentInChildren<Animator>();
            audioSource = GetComponentInChildren<AudioSource>();

            base.Start();

        }

        public override void Damage(int amount, DamageType type) 
        {

            if(currentState == EnemyState.Idle)
            {
                currentState = EnemyState.Follow;
                animator.SetBool("Walk", true);
            }
            
            if(!audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = damageAudio;
                audioSource.Play();
            }

            base.Damage(amount, type);

        }

        protected override void Idle()
        {

            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if(distanceToPlayer <= followDistance)
            {
                currentState = EnemyState.Follow;
                animator.SetBool("Walk", true);
                return;
            }

        }

        protected override void Follow()
        {

            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if(distanceToPlayer > 2.0f * followDistance)
            {
                currentState = EnemyState.Idle;
                animator.SetBool("Walk", false);
                return;
            } 
            else if(distanceToPlayer <= attackDistance)
            {
                currentState = EnemyState.Attack;
                return;
            }

            updatePathTimer += Time.deltaTime;
            if(updatePathTimer > 0.25f)
                agent.SetDestination(player.transform.position);

        }

        protected override void Attack()
        {

            if(!attacking)
            {
                attacking = true;
                agent.ResetPath();

                animator.SetBool("Walk", false);
                animator.SetBool("Attack", true);

                audioSource.Stop();
                audioSource.clip = attackAudio;
                audioSource.Play();

                StartCoroutine(PerformAttack());
            }

        }

        protected abstract IEnumerator PerformAttack();

        public virtual void EndAttack()
        {

            if(currentState == EnemyState.Dead)
                return;

            attacking = false;
            animator.SetBool("Attack", false);

            animator.SetBool("Walk", true);
            currentState = EnemyState.Follow;

        }

        protected override void Die()
        {

            currentState = EnemyState.Dead;
            agent.ResetPath();

            animator.SetBool("Dead", true);

            Destroy(this);

        }

    }

}
