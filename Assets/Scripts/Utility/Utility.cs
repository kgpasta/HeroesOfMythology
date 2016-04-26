using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Utility
    {
        public static GameObject GetPlayer()
        {
            return GameObject.Find("Player");
        }

        public static GameObject GetOpponent()
        {
            return GameObject.Find("Opponent");
        }

        public static GameBoard GetBoard()
        {
            return GameObject.Find("Board Manager").GetComponent<BoardGenerator>().Board;
        }

        public static StateMachine GetStateMachine()
        {
            return GameObject.Find("State Manager").GetComponent<StateMachine>();
        }

        public static int ConvertCoordinate(float a)
        {
            return Mathf.CeilToInt(a);
        }

        public static float ConvertFloat(int a)
        {
            return a - 0.5f;
        }

        public static Coordinate MouseToCoordinate(Vector3 vect)
        {
            Vector3 vector = Camera.main.ScreenToWorldPoint(vect);
            return new Coordinate(ConvertCoordinate(vector.x), ConvertCoordinate(vector.y));
        }
    }
}
