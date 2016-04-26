using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public class UnitBaseStats : ScriptableObject
    {
        public int Movement;
        public int AttackRange;
        public int HP;
        public int Attack;
        public int Defense;
        public int Accuracy;
        public int Critical;

        public void Load(string line)
        {
            string[] elements = line.Split(',');
            name = elements[0];
            Movement = Convert.ToInt32(elements[1]);
            AttackRange = Convert.ToInt32(elements[2]);
            HP = Convert.ToInt32(elements[3]);
            Attack = Convert.ToInt32(elements[4]);
            Defense = Convert.ToInt32(elements[5]);
            Accuracy = Convert.ToInt32(elements[6]);
            Critical = Convert.ToInt32(elements[7]);
        }
    }
}
