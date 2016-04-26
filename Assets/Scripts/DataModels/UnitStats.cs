using UnityEngine;
using System.Collections;
using Assets.Scripts.ScriptableObjects;

public class UnitStats : MonoBehaviour {

    public int Movement;
    public int AttackRange;
    public int HP;
    public int Attack;
    public int Defense;
    public int Accuracy;
    public int Critical;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadBaseStats(UnitBaseStats BaseStats)
    {
        Movement = BaseStats.Movement;
        AttackRange = BaseStats.AttackRange;
        HP = BaseStats.HP;
        Attack = BaseStats.Attack;
        Defense = BaseStats.Defense;
        Accuracy = BaseStats.Accuracy;
        Critical = BaseStats.Critical;
    }
}
