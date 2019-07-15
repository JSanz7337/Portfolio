﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<string> Items{get;set;} = new List<string>();
        public static ItemDatabase Instance {get; private set;}

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }else
            {
                Instance = this;
            }
            Items.Add("Emeral Slipper");
            Items.Add("Empty Chalice");
            Items.Add("Bowtie");
        }
    }
}
