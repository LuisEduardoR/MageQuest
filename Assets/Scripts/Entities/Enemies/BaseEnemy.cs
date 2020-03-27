using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using MageQuest.Player;

namespace MageQuest.Entities
{

    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class BaseEnemy : BaseEntity
    {
        
        public enum EnemyState { Idle, Follow, Attack, Dead }

        [SerializeField] protected EnemyState currentState = EnemyState.Idle;

        protected NavMeshAgent agent;

        protected PlayerEntity player;

        protected override void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            agent.speed = velocity;

            player = FindObjectOfType<PlayerEntity>();

            base.Start();

        }

        protected void Update()
        {

            switch(currentState)
            {

                case EnemyState.Idle:

                    Idle();
                    break;

                case EnemyState.Follow:

                    Follow();
                    break;

                case EnemyState.Attack:

                    Attack();
                    break;

                case EnemyState.Dead:
                    return;

            }

        }

        protected abstract void Idle();

        protected abstract void Follow();

        protected abstract void Attack();

    }

}
