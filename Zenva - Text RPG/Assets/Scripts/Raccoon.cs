using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Raccoon : Enemy
    {
        public Enemy Enemy {get;set;}
        public Player Player { get; set; }
        public Walrus Walrus { get; set; }

        // Start is called before the first frame update
        void Start()
        {

            Energy = 10;
            Attack = 5;
            Defense = 3;
            Gold = 20;
            Inventory.Add("Bandit Mask");
        }
    }

}
