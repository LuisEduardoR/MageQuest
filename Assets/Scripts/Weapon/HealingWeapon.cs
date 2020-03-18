using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Weapons
{

    [RequireComponent(typeof(AudioSource))]
    public class HealingWeapon : BaseWeapon
    {
        
        [SerializeField] protected int healAmount = 10;

        public override void Fire()
        {
            if(player.Mana >= manaCost && player.Health < 100)
            {
                player.GiveHealth(healAmount);
                base.Fire();
            }
        }

    }

}
