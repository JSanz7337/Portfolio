using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Room : MonoBehaviour
    {
        public Chest Chest{get;set;}
        public Enemy Enemy{get;set;}
        publicc bool Exit{get;set;}
        public bool Empty{get;set;}
        public Vector2 RoomIndex{get;set;}
    }
}
