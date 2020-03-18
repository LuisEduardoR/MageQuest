using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Weapons
{

    public class ProjectileWeapon : BaseWeapon
    {
        
        [SerializeField] protected GameObject projectile = null;
        [SerializeField] protected Transform spawn = null;

        public override void Fire()
        {
            if(player.Mana >= manaCost)
            {
                Instantiate(projectile, spawn.position, spawn.rotation);
                base.Fire();
            }
        }

    }

}
