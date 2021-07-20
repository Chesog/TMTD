using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using System.IO;

namespace TMTD
{
    class Gameplay
    {
        private Player player;
        private Background background;
        public Gameplay() 
        {

        }
        public void UpdateGameplay() 
        {
            player.UpdatePlayer();
            background.UpdateBackground();
        }
        public void DrawGameplay(RenderWindow window) 
        {
            background.DrawBackground(window);
            player.DrawPlayer(window);
        }
    }
}
