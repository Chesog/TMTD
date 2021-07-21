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
        private Player player;
        private Locations CurrenLocation;
        public Background()
        {
            
        }
        public Background(Player player) 
        {
            CurrenLocation = player.GetLocations();
        }
        public void UpdateBackground()
        {

        }
        public void DrawBackground(RenderWindow window)
        {
            switch (CurrenLocation)
            {
                case Locations.Village:
                    DrawBacgroundVillage(window);
                    break;
                case Locations.Castle:
                    DarwBackgroundCastle(window);
                    break;
                case Locations.Forest:
                    DrawBackgroundForest(window);
                    break;
                case Locations.Home:
                    DrawBackgroundHome(window);
                    break;
                case Locations.Shop:
                    DrawBacgroundShop(window);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        private void DrawBackgroundHome(RenderWindow window)
        {
            texture = new Texture("Background/Sprites/Home/Home.jpg");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
        private void DrawBackgroundForest(RenderWindow window)
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
        private void DrawBacgroundVillage(RenderWindow window)
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
        private void DarwBackgroundCastle(RenderWindow window)
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
        private void DrawBacgroundShop(RenderWindow window)
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
        private void DrawBacgroundMenu(RenderWindow window)
        {
            texture = new Texture("");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(2.9f, 3.5f);
            window.Draw(sprite);
        }
    }
}
