using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameBoard
    {
        Dictionary<Coordinate, GameTile> Board;

        public GameBoard()
        {
            Board = new Dictionary<Coordinate, GameTile>();
        }

        public GameTile GetTile(Coordinate coord)
        {
            GameTile tile;
            Board.TryGetValue(coord, out tile);
            return tile;
        }

        public List<GameTile> GetRange(Coordinate coord, int range)
        {
            List<GameTile> tiles = new List<GameTile>();
            List<Coordinate> GameTiles = Board.Keys.ToList();

            foreach (Coordinate target in GameTiles)
            {
                if (coord.GetDistance(target) <= range)
                {
                    tiles.Add(Board[target]);
                }
            }

            return tiles;
        }

        public void SetTile(Coordinate coord, GameTile tile)
        {
            Board.Add(coord, tile);
        }

    }

    public class GameTile
    {
        public GameObject TileObject;
        public bool isHighlighted = false;

        public GameTile(GameObject tileObject)
        {
            TileObject = tileObject;
        }

        public Coordinate ToCoordinate()
        {
            int x = Utility.ConvertCoordinate(TileObject.transform.position.x);
            int y = Utility.ConvertCoordinate(TileObject.transform.position.y);
            return new Coordinate(x, y);
        }

        public void Highlight()
        {
            if (!isHighlighted)
            {
                TileObject.GetComponent<SpriteRenderer>().color = Color.red;
                isHighlighted = true;

            }
            else
            {
                TileObject.GetComponent<SpriteRenderer>().color = Color.white;
                isHighlighted = false;
            }
        }
    }

    public class Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int xi, int yi)
        {
            x = xi;
            y = yi;
        }

        public int GetDistance(Coordinate coord)
        {
            int diffx = Math.Abs(this.x - coord.x);
            int diffy = Math.Abs(this.y - coord.y);
            return diffx + diffy;
        }

        public override bool Equals(System.Object o)
        {
            Coordinate c = (Coordinate)o;
            if (c.x == x && c.y == y)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + x;
            hash = hash * 31 + y;
            return hash;
        }

        public override string ToString()
        {
            return "{" + x + " , " + y + "}";
        }

    }
}
