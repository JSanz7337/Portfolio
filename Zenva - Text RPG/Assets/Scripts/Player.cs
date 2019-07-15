using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Player : Character
    {
        public int Floor{get;set;}
        // Start is called before the first frame update
        void Start()
        {
            Floor = 0;
            Energy = 30;
            Attack = 10;
            Defense = 5;
            Gold = 0;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2,2);
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        //Override methods for the player character
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
