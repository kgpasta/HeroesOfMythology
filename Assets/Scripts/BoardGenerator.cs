using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;

public class BoardGenerator : MonoBehaviour {

    const int WorldSizeX = 8;
    const int WorldSizeY = 4;
    public GameObject BackgroundTile;
    public GameObject UnitPrefab;
    public GameObject EnemyPrefab;
    public GameBoard Board;
    Player Player;
    Player Opponent;

    void Awake()
    {
        Board = new GameBoard();
        Player = Utility.GetPlayer().GetComponent<Player>();
        Opponent = Utility.GetOpponent().GetComponent<Player>();
    }

	// Use this for initialization
	void Start () {
        ConstantManager Constants = new ConstantManager();
        GenerateTiles();
        GenerateUnits();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void GenerateTiles()
    {
        for (float i = -WorldSizeX + 0.5f; i < WorldSizeX; i++)
        {
            for (float j = -WorldSizeY + 0.5f; j < WorldSizeY; j++)
            {
                GameObject SpaceTile = (GameObject)Instantiate(BackgroundTile);
                SpaceTile.transform.SetParent(this.transform);
                SpaceTile.transform.position = new Vector3(i, j, 10);

                GameTile tile = new GameTile(SpaceTile);
                Coordinate coord = new Coordinate(Utility.ConvertCoordinate(i), Utility.ConvertCoordinate(j));

                Board.SetTile(coord, tile);
            }
        }
    }

    void GenerateUnits()
    {
        
        GameObject Unit = Instantiate(UnitPrefab);
        Unit.transform.SetParent(Player.transform);
        UnitBaseStats baseStats = Resources.Load<UnitBaseStats>("Hero");
        Unit.GetComponent<UnitStats>().LoadBaseStats(baseStats);
        PlaceUnit(Unit, new Coordinate(-1, 1), Player);

        GameObject Unit2 = Instantiate(UnitPrefab);
        Unit2.transform.SetParent(Player.transform);
        Unit2.GetComponent<UnitStats>().LoadBaseStats(baseStats);
        PlaceUnit(Unit2, new Coordinate(-3, 2), Player);

        GameObject Enemy = Instantiate(EnemyPrefab);
        Enemy.transform.SetParent(Opponent.transform);
        baseStats = Resources.Load<UnitBaseStats>("Enemy");
        Enemy.GetComponent<UnitStats>().LoadBaseStats(baseStats);
        PlaceUnit(Enemy, new Coordinate(2, 1), Opponent);
    }

    void PlaceUnit(GameObject unit, Coordinate coord, Player player)
    {
        GameTile tile = Board.GetTile(coord);
        unit.transform.position = new Vector3(Utility.ConvertFloat(coord.x), Utility.ConvertFloat(coord.y), 0f);
        unit.GetComponent<Movement>().CurrentTile = tile;
        player.UnitRoster.AddUnit(unit);
    }

}
