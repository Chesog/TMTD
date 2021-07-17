using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TMTD
{
    class Background
    {
        private Texture texture;
        private Sprite sprite;
        public Background() 
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
        }
        public void UpdateBackground() 
        {

        }
        public void DrawBackground(RenderWindow window) 
        {
            window.Draw(sprite);
        }
    }
}
