using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace TMTD
{
    class Tile
    {
        private Sprite sprite;
        public Tile(Texture texture, Vector2f position) 
        {
            sprite = new Sprite(texture);
            sprite.Position = position;
        }
        public void Draw(RenderWindow window) 
        {
            window.Draw(sprite);
        }
    }
}
