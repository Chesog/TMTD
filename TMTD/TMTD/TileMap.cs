using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace TMTD
{
    class TileMap
    {
        private Tile tile;
        public TileMap(string tilepath , int tileWidht , int tileHeight) 
        {
            Texture texture = new Texture(tilepath , new IntRect(0,0,tileWidht , tileHeight));
            //tile = new Tile();
        }
    }
}
