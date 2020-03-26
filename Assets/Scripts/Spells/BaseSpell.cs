using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Spells
{

    public abstract class BaseSpell : MonoBehaviour
    {
        
        [SerializeField] protected int longCastManaCost = 10;

        public float delayShortCast = 0.5f;
        public float delayLongCast = 1.2f;

        [HideInInspector] public float castChargeTime;
        [HideInInspector] public bool inCooldown;

        protected PlayerEntity player;

        public virtual void Start() 
        {
            castChargeTime = 0;
            inCooldown = false;

            player = FindObjectOfType<PlayerEntity>();
        }

        public virtual void Update()
        {
            
            if(inCooldown)
            {
                castChargeTime -= Time.deltaTime;
                
                if(Input.GetButtonDown("Fire1"))
                {
                    if(castChargeTime <= 0)
                    {
                        castChargeTime = 0;
                        inCooldown = false;
                    }
                }

            }
            else
            {

                if(Input.GetButton("Fire1"))
                {
                    castChargeTime += Time.deltaTime;

                    if(castChargeTime > delayShortCast && player.Mana < longCastManaCost)
                    {
                        ShortCast();
                        inCooldown = true;
                        castChargeTime = delayShortCast;
                    }

                }

                if(Input.GetButtonUp("Fire1") && !inCooldown)
                {

                    if(castChargeTime < delayShortCast)
                    {
                        ShortCast();
                        castChargeTime = delayShortCast;
                    }
                    else
                    {
                        LongCast();
                        castChargeTime = delayLongCast;
                    }

                    inCooldown = true;

                }

            }
            
            
        }

        public abstract void ShortCast();

        public abstract void LongCast();

    }

}
