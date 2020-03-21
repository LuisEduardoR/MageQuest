using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MageQuest.Entities;

namespace MageQuest.Utility
{

    public class OnCollisionDamage : MonoBehaviour
    {
        
        [SerializeField] private int damageAmount = 10;
        [SerializeField] private DamageType damageType = DamageType.Normal;

        // Update is called once per frame
        void OnCollisionEnter(Collision collision)
        {
            BaseEntity entity = collision.transform.GetComponent<BaseEntity>();
            if(entity != null) entity.Damage(damageAmount, damageType);
        }

    }

}
