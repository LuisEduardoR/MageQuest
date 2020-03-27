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

        [SerializeField] private PlayerSpell[] spells = null;
        [SerializeField] private int currentSpell = 0;

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

            ui.UpdateAvaliableSpell(spells);

            currentSpell = 0;
            SetSpell(currentSpell);

            base.Start();

        }

        private void Update ()
        {

            // Allows using the number keys to pick a spell.
            for(int i = 1; i <= spells.Length; i++)
                if(Input.GetKeyDown(i.ToString()) && (i - 1) != currentSpell)
                    SetSpell(i - 1);

        }

        private void SetSpell(int spell)
        {

            if(spells[spell].spellEnabled)
            {
                spells[currentSpell].spellObject.SetActive(false);
                spells[spell].spellObject.SetActive(true);
                currentSpell = spell;
            }

            ui.UpdateCastingBar(spells[spell].spellScript);

        }

        protected override void Die()
        {

        }

    }

}
