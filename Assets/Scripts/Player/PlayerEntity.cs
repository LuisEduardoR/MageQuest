using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Spells;
using MageQuest.Entities;

namespace MageQuest.Player
{

    [RequireComponent(typeof(PlayerMovimentation))]
    [RequireComponent(typeof(PlayerUI))]
    public class PlayerEntity : BaseEntity
    {
        
        private PlayerMovimentation movement;
        private PlayerUI ui;

        [SerializeField] private PlayerSpell[] spells;
        [SerializeField] private int currentSpell;

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
            get { return mana; } 
            set 
            { 
                mana = Mathf.Clamp(value, 0, maxMana); 
                if(ui != null) ui.UpdateUIStats(health, maxHealth, mana, maxMana);
            }
        }

        protected override void Start()
        {

            movement = GetComponent<PlayerMovimentation>();
            movement.playerVelocity = velocity;

            ui = GetComponent<PlayerUI>();

            currentSpell = 0;
            SetSpell(currentSpell);

            base.Start();

        }

        private void Update ()
        {

            for(int i = 1; i <= spells.Length; i++)
            {

                if(Input.GetKeyDown(i.ToString()))
                {

                    SetSpell(i - 1);

                }

            }

        }

        private void SetSpell(int spell)
        {

            if(spells[spell].spellEnabled)
            {
                spells[currentSpell].spellObject.SetActive(false);
                spells[spell].spellObject.SetActive(true);
                currentSpell = spell;
            }

            ui.InitializeSpellBar(spells[spell].spellScript);

        }

        protected override void Die()
        {

        }

    }

}
