using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DataModels
{
    class WeaponStats : MonoBehaviour
    {
        public int Attack;
        public int Durability;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadBaseStats(WeaponBaseStats BaseStats)
        {
            Attack = BaseStats.Attack;
            Durability = BaseStats.Durability;
        }

    }
}
