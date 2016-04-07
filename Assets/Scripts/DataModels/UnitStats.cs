using UnityEngine;
using System.Collections;
using Assets.Scripts.ScriptableObjects;

public class UnitStats : MonoBehaviour {

    public int HP;
    public int Atk;
    public int Def;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadBaseStats(UnitBaseStats BaseStats)
    {
        HP = BaseStats.HP;
        Atk = BaseStats.Atk;
        Def = BaseStats.Def;
    }
}
