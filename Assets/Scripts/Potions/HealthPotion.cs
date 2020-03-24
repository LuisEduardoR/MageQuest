using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Potions
{

    public class HealthPotion : BasePotion
    {

        [SerializeField] protected int amount;
        [SerializeField] protected int period;

        protected override void ApplyPotion(PlayerEntity player)
        {

            if(player.Health < player.maxHealth)
            {

                player.GiveHealth(amount, period);
                Destroy(gameObject);

            }

        }

    }

}

        