using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Weapons
{
        
    public abstract class BaseWeapon : MonoBehaviour
    {

        protected PlayerScript player;
        protected AudioSource source;

        [SerializeField] protected int manaCost = 10;

        protected virtual void Start()
        {
            player = FindObjectOfType<PlayerScript>();
            source = GetComponentInChildren<AudioSource>();
        }

        public virtual void Fire()
        {
            if(player.Mana >= manaCost)
            {
                player.Mana -= manaCost;
                source.Play();
            }

        }
        
    }

}
