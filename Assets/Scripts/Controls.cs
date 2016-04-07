using Assets.Scripts;
using Assets.Scripts.Battle;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    GameBoard Board;
    List<GameTile> HighlightedTiles = null;

    // Use this for initialization
    void Start()
    {
        Board = Utility.GetBoard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectUnit(Coordinate position)
    {
        if(HighlightedTiles != null)
        {
            foreach (GameTile rangeTile in HighlightedTiles)
            {
                rangeTile.Highlight();
            }
        }


        HighlightedTiles = Board.GetRange(position, 4);
        foreach (GameTile rangeTile in HighlightedTiles)
        {
            rangeTile.Highlight();
        }
    }

    public bool MoveUnit(GameObject unit, Coordinate position)
    {
        GameTile tile = Board.GetTile(position);
        if (HighlightedTiles.Contains(tile))
        {
            //Visually move unit
            unit.transform.position = new Vector3(Utility.ConvertFloat(position.x), Utility.ConvertFloat(position.y), 0f);

            //Objectively move unit
            unit.GetComponent<Movement>().CurrentTile = tile;

            foreach (GameTile rangeTile in HighlightedTiles)
            {
                rangeTile.Highlight();
            }
            HighlightedTiles = null;

            return true;
        }
        return false;
    }

    public bool AttackUnit(GameObject unit, GameObject target, Coordinate position)
    {
        GameTile tile = Board.GetTile(position);

        BattleResult result = BattleComputer.Battle(unit, target);

        GameObject death = BattleComputer.ProcessBattleResult(unit, target, result);

        if(death != null)
        {
            death.SetActive(false);
        }

        return true;
    }
}
