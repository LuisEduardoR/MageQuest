using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Potions
{
        
    public class Potion : MonoBehaviour
    {

        public enum Type { Health, Mana }

        public Type potionType = Type.Health;
        public int amount = 25;

        void OnTriggerEnter(Collider other)
        {
            
            if(other.tag == "Player")
            {

                bool collected = false;
                PlayerScript player = other.GetComponent<PlayerScript>();

                if(potionType == Type.Health) 
                {
                    collected = player.GiveHealth(amount);
                }

                if(potionType == Type.Mana) 
                {
                    collected = player.GiveMana(amount);
                }

                if(collected)
                {
                    Destroy(gameObject);
                }

            }

        }
    }

}
