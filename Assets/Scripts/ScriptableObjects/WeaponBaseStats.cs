using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts.ScriptableObjects
{
    class WeaponBaseStats : ScriptableObject
    {
        public int Attack;
        public int Durability;

        public void Load(string line)
        {
            string[] elements = line.Split(',');
            name = elements[0];
            Attack = Convert.ToInt32(elements[1]);
            Durability = Convert.ToInt32(elements[2]);
        }
    }
}
