using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.States
{
    class EndTurnState : State
    {
        StateMachine StateMachine = Utility.GetStateMachine();
        Controls ControlFunctions = Utility.GetPlayer().GetComponent<Controls>();
        public override void Enter()
        {
            Debug.Log("Turn Over!");
            ControlFunctions.ResetHighlightedTiles();
            return;
        }

        public override void Exit()
        {
            return;
        }

        public override void Update()
        {
            return;
        }
    }
}
