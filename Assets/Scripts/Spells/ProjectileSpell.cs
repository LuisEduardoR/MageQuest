using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Spells
{

    [RequireComponent(typeof(AudioSource))]
    public class ProjectileSpell : BaseSpell
    {

        [SerializeField] protected int longCastManaCost = 10;

        [SerializeField] protected GameObject shortCastProjectile = null;
        [SerializeField] protected GameObject longCastProjectile = null;

        [SerializeField] protected Transform projectileSpawn = null;

        [SerializeField] protected AudioClip shortCastSound = null;
        [SerializeField] protected AudioClip longCastSound = null;

        protected AudioSource source;

        public override void Start()
        {

            source = GetComponent<AudioSource>();
            base.Start();

        }

        public override void ShortCast()
        {

            Instantiate(shortCastProjectile, projectileSpawn.position, projectileSpawn.rotation);
            
            source.Stop();
            source.clip = shortCastSound;
            source.Play();

        }

        public override void LongCast() 
        {

            if(player.Mana >= longCastManaCost)
            {
                Instantiate(longCastProjectile, projectileSpawn.position, projectileSpawn.rotation);

                source.Stop();
                source.clip = longCastSound;
                source.Play();

                player.Mana -= longCastManaCost;
            }

        }

    }
}
