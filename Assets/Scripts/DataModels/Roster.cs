using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Roster
    {
        public List<GameObject> Units;
        public List<GameObject> Graveyard;
        int UnitCount;

        public Roster()
        {
            Units = new List<GameObject>();
            Graveyard = new List<GameObject>();
            UnitCount = 0;
        }

        public void AddUnit(GameObject unit)
        {
            Units.Add(unit);
            UnitCount++;
        }

        public GameObject GetUnit(GameTile tile)
        {
            foreach(GameObject unit in Units)
            {
                if(unit.GetComponent<Movement>().CurrentTile == tile)
                {
                    return unit;
                }
            }
            return null;
        }

        public void MoveToGraveyard(GameObject unit)
        {
            Units.Remove(unit);
            Graveyard.Add(unit);
            UnitCount--;
        }

        public GameObject GetNextAvailableUnit()
        {
            foreach(GameObject unit in Units)
            {
                if (unit.GetComponent<Movement>().HasMovement)
                {
                    return unit;
                }
            }
            return null;
        }
    }
}
