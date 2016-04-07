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

            int attackerDamage = attackerStats.Atk - defenderStats.Def;
            int defenderDamage = defenderStats.Atk - attackerStats.Def;

            Debug.Log(attacker.name + " hit " + defender.name + " for " + attackerDamage + " damage!");
            Debug.Log(defender.name + " hit " + attacker.name + " for " + defenderDamage + " damage!");

            attackerStats.HP -= defenderDamage;
            defenderStats.HP -= attackerDamage;

            if(attackerStats.HP <= 0 && defenderStats.HP >= 0)
            {
                return BattleResult.Lose;
            } else if(attackerStats.HP >= 0 && defenderStats.HP <= 0)
            {
                return BattleResult.Win;
            }

            return BattleResult.Draw;
        }

        public static GameObject ProcessBattleResult(GameObject attacker, GameObject defender, BattleResult result)
        {
            attacker.GetComponent<SpriteRenderer>().color = Color.gray;
            attacker.GetComponent<Movement>().HasMovement = false;
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
