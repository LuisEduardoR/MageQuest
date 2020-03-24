using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Potions
{

    public abstract class BasePotion : MonoBehaviour
    {

        protected virtual void OnTriggerEnter(Collider other)
        {
            
            PlayerEntity player = other.GetComponent<PlayerEntity>();
            if(player != null)
            {
                ApplyPotion(player);
            }

        }

        protected abstract void ApplyPotion(PlayerEntity player);

    }

}
