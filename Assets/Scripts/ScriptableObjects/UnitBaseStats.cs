using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public class UnitBaseStats : ScriptableObject
    {
        public int HP;
        public int Atk;
        public int Def;

        public void Load(string line)
        {
            string[] elements = line.Split(',');
            name = elements[0];
            HP = Convert.ToInt32(elements[1]);
            Atk = Convert.ToInt32(elements[2]);
            Def = Convert.ToInt32(elements[3]);
        }
    }
}
