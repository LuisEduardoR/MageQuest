using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Potions
{

    public class ManaPotion : BasePotion
    {

        [SerializeField] protected int amount;
        [SerializeField] protected int period;

        protected override void ApplyPotion(PlayerEntity player)
        {

            if(player.Mana < player.maxMana)
            {

                player.GiveMana(amount, period);
                Destroy(gameObject);

            }

        }

    }

}

        