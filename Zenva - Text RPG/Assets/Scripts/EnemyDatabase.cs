using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class EnemyDatabase : MonoBehaviour
    {
        public List<Enemy> Enemies{get;set;} = new List<Enemy>();
        public static EnemyDatabase Instance{get;set;}
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }

            foreach (Enemy enemy in GetComponents<Enemy>())
            {
                Enemies.Add(enemy);    
            }
        }
    }
}
