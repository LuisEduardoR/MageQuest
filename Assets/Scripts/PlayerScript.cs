﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using MageQuest.Weapons;

namespace MageQuest.Player
{

    [RequireComponent(typeof(Movimentacao))]
    public class PlayerScript : MonoBehaviour
    {

        protected int health;
        public int Health {
            get  
            {
                return health;
            }
            set
            {
                health = Mathf.Clamp(value, 0, 100);
                UpdateUI();
            }
        }

        protected int mana;
        public int Mana {
            get
            {
                return mana;
            }
            set
            {
                mana = Mathf.Clamp(value, 0, 100);
                UpdateUI();
            }
        }

        protected int currentWeapon = 0;
        [SerializeField] protected GameObject[] weaponObjects = null;
        protected BaseWeapon[] weaponScripts;

        [System.Serializable]
        public class UI
        {
            public TMP_Text healthText;
            public TMP_Text manaText;
        }
        [SerializeField] UI playerUi;


        void Start()
        {
            Health = 100;
            Mana = 100;

            weaponScripts = new BaseWeapon[weaponObjects.Length];
            for(int i = 0; i < weaponObjects.Length; i++)
            {
                weaponScripts[i] = weaponObjects[i].GetComponent<BaseWeapon>();
            }
            SetWeapon(0);

        }

        void Update()
        {

            // Allows changing weapons.
            for(int i = 1; i <= weaponObjects.Length; i++)
            {
                if(Input.GetKeyDown(i.ToString()))
                {
                    SetWeapon(i - 1);
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                weaponScripts[currentWeapon].Fire();
            }

        }

        public void Damage(int amount)
        {
            Health -= amount;
            if(Health == 0)
            {
                Die();
            }

        }

        private void Die()
        {
            SceneManager.LoadScene("DeathScreen");
        }

        public bool GiveHealth(int amount)
        {
            
            if(Health == 100) 
            {
                return false;
            }  

            Health += amount;
            return true;

        }

        public bool GiveMana(int amount)
        {

            if(Mana == 100) 
            {
                return false;
            }

            Mana += amount;
            return true;

        }

        void UpdateUI() {

            playerUi.healthText.text = Health.ToString();
            playerUi.manaText.text = Mana.ToString();

        }

        void SetWeapon(int weapon) 
        {
            
            weaponObjects[currentWeapon].SetActive(false);
            weaponObjects[weapon].SetActive(true);

            currentWeapon = weapon;

        }

    }

}
