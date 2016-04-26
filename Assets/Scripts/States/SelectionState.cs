using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SelectionState : State
    {
        StateMachine StateMachine = Utility.GetStateMachine();
        Controls ControlFunctions;
        Player Player;
        GameObject SelectedUnit;

        public override void Enter()
        {
            Player = Utility.GetPlayer().GetComponent<Player>();
            ControlFunctions = Player.GetComponent<Controls>();

            SelectedUnit = Player.GetNextAvailableUnit();
            Coordinate coord = SelectedUnit.GetComponent<Movement>().CurrentTile.ToCoordinate();
            ControlFunctions.SelectUnit(SelectedUnit, coord);
        }

        public override void Exit()
        {
            return;
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Coordinate position = Utility.MouseToCoordinate(Input.mousePosition);
                GameObject selected = Player.GetUnitLocation(position);

                if (selected == null)
                {
                    bool moveSuccessful = ControlFunctions.MoveUnit(SelectedUnit, position);
                    if (moveSuccessful)
                    {
                        ActionState actionState = new ActionState();
                        actionState.SelectedUnit = SelectedUnit;
                        StateMachine.Transition(actionState);
                    }

                }
                else
                {
                    SelectedUnit = selected;
                    ControlFunctions.SelectUnit(SelectedUnit, position);
                }
                
            }
        }
    }
}
