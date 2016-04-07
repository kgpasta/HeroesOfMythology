using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    class ConstantManager
    {
        Dictionary<string, string> Constants;

        public ConstantManager()
        {
            Constants = new Dictionary<string, string>();

            PopulateDictionary();
        }

        void PopulateDictionary()
        {
            string[] readText = File.ReadAllLines("Assets/Resources/UnitStats.csv");
            string filePath = "Assets/Resources/";
            for (int i = 1; i < readText.Length; ++i)
            {
                UnitBaseStats baseStats = ScriptableObject.CreateInstance<UnitBaseStats>();
                baseStats.Load(readText[i]);
                string fileName = string.Format("{0}{1}.asset", filePath, baseStats.name);
                AssetDatabase.CreateAsset(baseStats, fileName);
            }
        }
    }

    [Serializable]
    public class UnitLocationsOwner
    {
        public List<UnitLocations> UnitLocations;
    }

    [Serializable]
    public class UnitLocations
    {
        public int x;
        public int y;
    }

}
