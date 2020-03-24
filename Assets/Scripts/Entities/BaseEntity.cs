using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Entities
{

    public enum DamageType { Normal }
    public enum EffectOverTime { HealthRegen, ManaRegen }

    public abstract class BaseEntity : MonoBehaviour
    {

        [SerializeField] protected int health = 100;
        public virtual int Health
        {
            get { return health; } 
            set { health = Mathf.Clamp(value, 0, maxHealth); }
        }
        public int maxHealth = 100;

        [SerializeField] protected int mana = 100;
        public virtual int Mana
        {
            get { return health; } 
            set { health = Mathf.Clamp(value, 0, maxMana); }
        }
        public int maxMana = 100;

        [SerializeField] protected float velocity = 5.0f;

        protected virtual void Start()
        {

            Health = maxHealth;
            Mana = maxMana;

        }

        public virtual void GiveHealth(int amount, int period)
        {

            if(period > 0) StartCoroutine(GiveOverTime(EffectOverTime.HealthRegen, amount, period)); // Starts giving health overtime subroutine.
            else Health += amount; // Give all health imediatly,

        }

        public virtual void GiveMana(int amount, int period)
        {

            if(period > 0) StartCoroutine(GiveOverTime(EffectOverTime.ManaRegen, amount, period)); // Starts giving mana overtime subroutine.
            else Mana += amount; // Give all mana imediatly,

        }

        protected virtual IEnumerator GiveOverTime(EffectOverTime effectOverTime, int amount, int period) {

            int step = (int)Mathf.Floor(amount / period); // Calculates the amount of mana/sec.
            int curStep = 0; // Stores the amount of times mana was given.
            while(curStep < period)
            {

                // Waits for a second (done this way so we are able to pause time).
                float timer = 0;
                while(timer < 1.0f)
                {
                    timer += Time.fixedDeltaTime;
                    yield return new WaitForFixedUpdate();
                }
                
                // Gives the resource effect.
                switch(effectOverTime)
                {
                    case EffectOverTime.HealthRegen:

                        Health += step;
                        break;

                    case EffectOverTime.ManaRegen:
                    
                        Mana += step;
                        break;

                }
                curStep++;
                
            }

             // Ensures any error from the division will be given to the entity in the end.
            switch(effectOverTime)
            {
                case EffectOverTime.HealthRegen:

                    Health += step % period;
                    break;

                case EffectOverTime.ManaRegen:
                
                    Mana += step % period;
                    break;

            }
            

        }

        public virtual void Damage(int amount, DamageType type) 
        { 
            
            Health -= amount;
            if(Health == 0) Die(); // Kill the entity when needed. 
            
        }

        protected abstract void Die();

    }

}
