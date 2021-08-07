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
        private TileMap collisiones;

        public Gameplay() 
        {
            player = new Player("Max",1000,100,0,100, Locations.Home ,10,18);
            AllBackground.GetInstance();
            
            invisibleWall = new InvisibleWall(new Vector2f(7500.0f,700.0f) , new Vector2f(200.0f,200.0f));
            collisiones = new TileMap("TileMap" + Path.DirectorySeparatorChar + "TilesExamples.png", "TileMap" + Path.DirectorySeparatorChar + "1level1.csv", 16, 16, 26, new Vector2f(4.0f, 4.0f), TileMapType.Collisionable);
        }
        public void UpdateGameplay() 
        {
            if (player != null)
            {
                player.Update();
            }

            AllBackground.GetInstance().UpdateBackground(player.GetLocations());
            
        }
        public void DrawGameplay(RenderWindow window) 
        {
            AllBackground.GetInstance().DrawBackground(window);
            if (player != null)
            {
                player.Draw(window);
            }
            if (wall != null)
            {
                wall.Draw(window);
            }
            if (collisiones != null)
            {
                collisiones.Draw(window);
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
            if (invisibleWall != null)
            {
                if (invisibleWall.ToDelete == true)
                {
                    invisibleWall.RemoveFromColitionManager();
                    invisibleWall = null;
                }
            }         
        }
    }
}
