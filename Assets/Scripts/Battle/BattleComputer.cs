using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Battle
{
    public enum BattleResult
    {
        Win,
        Lose,
        Draw
    }

    class BattleComputer
    {
        public static BattleResult Battle(GameObject attacker, GameObject defender)
        {
            UnitStats attackerStats = attacker.GetComponent<UnitStats>();
            UnitStats defenderStats = defender.GetComponent<UnitStats>();

            int attackerHit = (int) (UnityEngine.Random.value * 100);
            int defenderHit = (int) (UnityEngine.Random.value * 100);

            Debug.Log(attackerStats.name + " rolled a " + attackerHit + ", hit % was " + attackerStats.Accuracy);
            if(attackerStats.Accuracy >= attackerHit)
            {
                int attackerDamage = CalculateDamage(attackerStats, defenderStats);
                Debug.Log(attacker.name + " hit " + defender.name + " for " + attackerDamage + " damage!");
            }
            else
            {
                Debug.Log(attacker.name + " missed!");
            }

            Debug.Log(defenderStats.name + " rolled a " + defenderHit + ", hit % was " + defenderStats.Accuracy);
            if (defenderStats.Accuracy >= defenderHit)
            {
                int defenderDamage = CalculateDamage(defenderStats, attackerStats);
                Debug.Log(defender.name + " hit " + attacker.name + " for " + defenderDamage + " damage!");
            }
            else
            {
                Debug.Log(defender.name + " missed!");
            }

            if(attackerStats.HP <= 0 && defenderStats.HP >= 0)
            {
                return BattleResult.Lose;
            } else if(attackerStats.HP >= 0 && defenderStats.HP <= 0)
            {
                return BattleResult.Win;
            }

            return BattleResult.Draw;
        }

        private static int CalculateDamage(UnitStats attackerStats, UnitStats defenderStats)
        {
            int attackerDamage = attackerStats.Attack - defenderStats.Defense;
            int attackerCritical = (int)(UnityEngine.Random.value * 100);

            if (attackerStats.Critical >= attackerCritical)
            {
                attackerDamage = attackerDamage * 2;
                Debug.Log("Critical Hit!");
            }

            defenderStats.HP -= attackerDamage;
            return attackerDamage;
        }

        public static GameObject ProcessBattleResult(GameObject attacker, GameObject defender, BattleResult result)
        {
            if(result == BattleResult.Win)
            {
                defender.GetComponentInParent<Player>().SendToGraveyard(defender);
                return defender;
            } else if(result == BattleResult.Lose)
            {
                attacker.GetComponentInParent<Player>().SendToGraveyard(attacker);
                return attacker;
            }
            return null;
        }
    }
}
