using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public GameBoard Board;
    public Roster UnitRoster;

	// Use this for initialization
	void Start () {
        UnitRoster = new Roster();
        Board = Utility.GetBoard();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public GameObject GetNextAvailableUnit()
    {
        return UnitRoster.GetNextAvailableUnit();
    }

    public GameObject GetUnitLocation(Coordinate coord)
    {
        GameTile tile = Board.GetTile(coord);
        return UnitRoster.GetUnit(tile);
    }

    public bool SendToGraveyard(GameObject unit)
    {
        if (UnitRoster.Units.Contains(unit))
        {
            UnitRoster.MoveToGraveyard(unit);
            return true;
        }
        return false;
    }
}
