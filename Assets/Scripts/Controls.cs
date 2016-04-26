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

    public void SelectUnit(GameObject unit, Coordinate position)
    {
        UnitStats stats = unit.GetComponent<UnitStats>();
        HighlightedTiles = Board.GetRange(position, stats.Movement);
        BoardOverlay.HighlightTiles(HighlightedTiles);
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

            UnitStats stats = unit.GetComponent<UnitStats>();

            HighlightedTiles = Board.GetRange(position,stats.AttackRange);
            BoardOverlay.HighlightTiles(HighlightedTiles);

            unit.GetComponent<Movement>().HasMovement = false;

            return true;
        }
        return false;
    }

    public bool ValidTargetExists()
    {
        Player Opponent = Utility.GetOpponent().GetComponent<Player>();
        foreach (GameTile highlightedTile in HighlightedTiles)
        {
            GameObject enemy = Opponent.GetUnitLocation(highlightedTile.ToCoordinate());
            if (enemy != null)
            {
                return true;
            }
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

        HighlightedTiles = null;
        BoardOverlay.HighlightTiles(HighlightedTiles);

        return true;
    }

    public void ResetHighlightedTiles()
    {
        HighlightedTiles = null;
        BoardOverlay.HighlightTiles(HighlightedTiles);
    }
}
