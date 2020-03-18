using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MageQuest.Player
{

    [RequireComponent(typeof(Movimentacao))]
    public class PlayerScript : MonoBehaviour
    {

        private int health;
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

        private int mana;
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

        [System.Serializable]
        public class UI
        {
            public TMP_Text healthText;
            public TMP_Text manaText;
        }
        [SerializeField] UI playerUi;


        public void Start()
        {
            Health = 100;
            Mana = 100;
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
            SceneManager.LoadScene("Morte");
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

    }

}
