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
        public override void Enter()
        {
            Debug.Log("Turn Over!");
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
