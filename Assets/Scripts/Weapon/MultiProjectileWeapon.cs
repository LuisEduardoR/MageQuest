using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Weapons
{

    public class MultiProjectileWeapon : BaseWeapon
    {
        
        [SerializeField] protected GameObject projectile = null;
        [SerializeField] protected Transform[] spawns = null;

        public override void Fire()
        {
            if(player.Mana >= manaCost)
            {
                foreach(Transform spawn in spawns)
                {
                    Instantiate(projectile, spawn.position, spawn.rotation);
                }
                base.Fire();
            }
        }

    }

}
