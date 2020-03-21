using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Entities;

namespace MageQuest.Player
{

    [RequireComponent(typeof(PlayerMovimentation))]
    [RequireComponent(typeof(PlayerUI))]
    public class PlayerEntity : BaseEntity
    {
        
        private PlayerMovimentation movement;
        private PlayerUI ui;

        public override int Health
        {
            get { return health; } 
            set 
            { 
                health = Mathf.Clamp(value, 0, maxHealth);
                if(ui != null) ui.UpdateUIStats(health, maxHealth, mana, maxMana); 
            }
        }
        public override int Mana
        {
            get { return health; } 
            set 
            { 
                health = Mathf.Clamp(value, 0, maxMana); 
                if(ui != null) ui.UpdateUIStats(health, maxHealth, mana, maxMana);
            }
        }

        protected override void Start()
        {

            movement = GetComponent<PlayerMovimentation>();
            movement.playerVelocity = velocity;

            ui = GetComponent<PlayerUI>();

            base.Start();

        }

        private void Update ()
        {

        }

        protected override void Die()
        {

        }

    }

}
