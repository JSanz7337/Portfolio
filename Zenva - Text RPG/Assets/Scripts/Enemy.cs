using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG{
    public class Enemy : Character
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        //Override the methods for enemies
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
        }
        public override void Die()
        {
            base.Die();
            Debug.Log("The enemy Died.");
        }
    }
}
