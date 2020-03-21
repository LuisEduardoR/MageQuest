using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Potions
{
    
    [RequireComponent(typeof(Collider))]
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

                switch(potionType)
                {
                    case Type.Health:

                       collected = player.GiveHealth(amount);
                       break;

                    case Type.Mana:

                        collected = player.GiveMana(amount);
                        break;

                }

                if(collected)
                {
                    Destroy(gameObject);
                }

            }

        }
    }

}
