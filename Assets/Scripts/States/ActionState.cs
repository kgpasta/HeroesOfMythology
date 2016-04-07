using Assets.Scripts.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class ActionState : State
    {
        StateMachine StateMachine = Utility.GetStateMachine();
        Controls ControlFunctions;
        Player Player;
        public GameObject SelectedUnit;

        public override void Enter()
        {
            Player = Utility.GetPlayer().GetComponent<Player>();
            ControlFunctions = Player.GetComponent<Controls>();
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

                if(selected != null)
                {
                    bool attackSuccessful = ControlFunctions.AttackUnit(SelectedUnit, selected, position);
                    if (attackSuccessful)
                    {
                        if(Player.GetNextAvailableUnit() == null)
                        {
                            StateMachine.Transition(new EndTurnState());
                        }
                        else
                        {
                            StateMachine.Transition(new SelectionState());
                        }

                    }
                }
            }
        }
    }
}
