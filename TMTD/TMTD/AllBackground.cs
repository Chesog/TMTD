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
    class AllBackground 
    {
        private Locations CurrenLocation;
        private List<Background> loadedBackground;

        public AllBackground(Player player) 
        {
            CurrenLocation = player.GetLocations();
            loadedBackground = new List<Background>();
            loadedBackground.Add(new Background("Background/Sprites/Home/Home.jpg", new Vector2f (2.2f, 2.2f) ,Locations.Home));
        }
        public void UpdateBackground(Player player)
        {
            CurrenLocation = player.GetLocations();
        }
        public void DrawBackground(RenderWindow window)
        {
            for (int i = 0; i < loadedBackground.Count; i++)
            {
                if (CurrenLocation == loadedBackground[i].GetLocationName())
                {
                    window.Draw(loadedBackground[i].GetSprite());
                }
            }
            
           // switch (CurrenLocation)
           // {
           //     case Locations.Village:
           //         DrawBacgroundVillage(window);
           //         break;
           //     case Locations.Castle:
           //         DarwBackgroundCastle(window);
           //         break;
           //     case Locations.Forest:
           //         DrawBackgroundForest(window);
           //         break;
           //     case Locations.Home:
           //         DrawBackgroundHome(window);
           //         break;
           //     case Locations.Shop:
           //         DrawBacgroundShop(window);
           //         break;
           //     default:
           //         Console.WriteLine("Error");
           //         break;
           // }
        }
       // private void DrawBackgroundHome(RenderWindow window)
       // {
       //     texture = new Texture("Background/Sprites/Home/Home.jpg");
       //     sprite = new Sprite(texture);
       //     sprite.Scale = new Vector2f(2.2f, 2.2f);
       //     window.Draw(sprite);
       // }
       // private void DrawBackgroundForest(RenderWindow window)
       // {
       //     window.Draw(sprite);
       // }
       // private void DrawBacgroundVillage(RenderWindow window)
       // {
       //     window.Draw(sprite);
       // }
       // private void DarwBackgroundCastle(RenderWindow window)
       // {
       //     window.Draw(sprite);
       // }
       // private void DrawBacgroundShop(RenderWindow window)
       // {
       //     window.Draw(sprite);
       // }
       // private void DrawBacgroundMenu(RenderWindow window)
       // {
       //     window.Draw(sprite);
       // }
    }
}
