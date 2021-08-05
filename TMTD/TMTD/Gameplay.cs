using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using System.IO;

namespace TMTD
{
    class Gameplay
    {
        private Player player;
        private Wall wall;
        private AllBackground background;
        private InvisibleWall invisibleWall;
        public Gameplay() 
        {
            player = new Player("Max",1000,100,0,100, Locations.Home ,10,18);
            wall = new Wall();
            background = new AllBackground(player);
            invisibleWall = new InvisibleWall(new Vector2f(1000.0f,900.0f) , new Vector2f(200.0f,200.0f));
        }
        public void UpdateGameplay() 
        {
            if (player != null)
            {
                player.Update();
            }
            
            background.UpdateBackground(player);
            
        }
        public void DrawGameplay(RenderWindow window) 
        {
            background.DrawBackground(window);
            if (player != null)
            {
                player.Draw(window);
            }
            if (wall != null)
            {
                wall.Draw(window);
            }
            
        }
        public void CheckGarbage() 
        {
            if (player != null)
            {
                player.CheckGarbage();
                if (player.toDelelte)
                {
                    player = null;
                }
            }
            if (wall != null)
            {
                wall.CheckGarbage();
                if (wall.toDelelte)
                {
                    wall = null;
                }
            }
            
           
        }
    }
}
