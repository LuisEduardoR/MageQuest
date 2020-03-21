using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Entities
{

    public enum DamageType { Normal }

    public abstract class BaseEntity : MonoBehaviour
    {

        [SerializeField] protected int health = 100;
        public virtual int Health
        {
            get { return health; } 
            set { health = Mathf.Clamp(value, 0, maxHealth); }
        }
        [SerializeField] protected int maxHealth = 100;

        [SerializeField] protected int mana = 100;
        public virtual int Mana
        {
            get { return health; } 
            set { health = Mathf.Clamp(value, 0, maxMana); }
        }
        [SerializeField] protected int maxMana = 100;

        [SerializeField] protected float velocity = 5.0f;

        protected virtual void Start()
        {

            Health = maxHealth;
            Mana = maxMana;

        }

        public virtual void Heal(int amount, int period)
        {

            if(period > 0) StartCoroutine(HealOverTime(amount, period)); // Starts healing subroutine.
            else Health += amount; // Heals imediatly,

        }

        protected virtual IEnumerator HealOverTime(int amount, int period) {

            int step = (int)Mathf.Floor(amount / period); // Calculates the amount of health/sec.
            int curStep = 0; // Stores the amount of times health was given.
            while(curStep < period)
            {

                // Waits for a second (done this way so we are able to pause time).
                float timer = 0;
                while(timer < 1.0f)
                {
                    timer += Time.fixedDeltaTime;
                    yield return new WaitForFixedUpdate();
                }
                
                // Heals.
                Health += step;
                curStep++;
                
            }

            Health += step % period; // Ensures any error from the division will be given to the entity in the end.

        }

        public virtual void Damage(int amount, DamageType type) 
        { 
            
            Health -= amount;
            if(Health == 0) Die(); // Kill the entity when needed. 
            
        }

        protected abstract void Die();

    }

}
