using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class BoardOverlay
    {

        public static void HighlightTiles(List<GameTile> tiles)
        {
            List<GameTile> allTiles = Utility.GetBoard().GetAllTiles();

            foreach (GameTile tile in allTiles)
            {
                tile.TileObject.GetComponent<SpriteRenderer>().color = Color.white;
            }

            if(tiles != null)
            {
                foreach (GameTile rangeTile in tiles)
                {
                    rangeTile.TileObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }
}
