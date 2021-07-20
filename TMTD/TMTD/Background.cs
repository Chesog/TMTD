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
        private Background background;
        public Background()
        {

        }
        public void UpdateBackground()
        {

        }
        public void DrawBackground(RenderWindow window)
        {
            switch (player.GetLocations())
            {
                case Locations.Village:
                    background.DrawBacgroundVillage(window);
                    break;
                case Locations.Castle:
                    background.DarwBackgroundCastle(window);
                    break;
                case Locations.Forest:
                    background.DrawBackgroundForest(window);
                    break;
                case Locations.Home:
                    background.DrawBackgroundHome(window);
                    break;
                case Locations.Shop:
                    background.DrawBacgroundShop(window);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        private void DrawBackgroundHome(RenderWindow window)
        {
            texture = new Texture("");
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
