using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Player;

namespace MageQuest.Spells
{

    public abstract class BaseSpell : MonoBehaviour
    {
        
        [SerializeField] protected float delayBetweenCasts = 0.1f;
        protected float castTimer;

        [SerializeField] protected float longCastCharge = 0.3f;
        protected float longCastTimer;

        protected PlayerEntity player;

        public virtual void Start() 
        {
            castTimer = 0;
            longCastTimer = 0;

            player = FindObjectOfType<PlayerEntity>();
        }

        public virtual void Update()
        {
            
            if(castTimer < delayBetweenCasts)
                castTimer += Time.deltaTime;

            if(Input.GetButton("Fire1") && castTimer >= delayBetweenCasts)
            {
                longCastTimer += Time.deltaTime;
            }

            if(Input.GetButtonUp("Fire1") && castTimer >= delayBetweenCasts)
            {
                if(longCastTimer < longCastCharge) ShortCast();
                else LongCast();

                castTimer = 0;
                longCastTimer = 0;
            }
            
            
        }

        public abstract void ShortCast();

        public abstract void LongCast();

    }

}
