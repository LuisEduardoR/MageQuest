using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MageQuest.Spells
{

    [RequireComponent(typeof(Rigidbody))] 
    public class SpawnProjectile : BaseProjectile
    {
        
        [SerializeField] protected GameObject objectToSpawn;

        protected override void DestroyProjectile()
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            base.DestroyProjectile();
        }

    }

}