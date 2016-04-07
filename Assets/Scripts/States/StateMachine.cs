using Assets.Scripts.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState = null;
        bool inTransition = false;

        void Start() {
            Transition(new BeginTurnState());
        }

        void Update() {
            if(CurrentState != null)
            {
                CurrentState.Update();
            }

        }

        public void Transition(State state)
        {
            Debug.Log("Transitioning from " + CurrentState + " to " + state);
            if (CurrentState == state || inTransition)
                return;

            inTransition = true;

            if (CurrentState != null)
                CurrentState.Exit();

            CurrentState = state;

            if (CurrentState != null)
                CurrentState.Enter();

            inTransition = false;
        }
    }

    public abstract class State
    {
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
    }
}
