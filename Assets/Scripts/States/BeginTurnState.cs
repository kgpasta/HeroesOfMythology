using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.States
{
    class BeginTurnState : State
    {
        StateMachine StateMachine = Utility.GetStateMachine();
        public override void Enter()
        {
            return;
        }

        public override void Exit()
        {
            return;
        }

        public override void Update()
        {
            StateMachine.Transition(new SelectionState());
        }
    }
}
