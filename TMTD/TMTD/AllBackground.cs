using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

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
            loadedBackground.Add(new Background("Background/Sprites/Forest/Bosque.jpg", new Vector2f(2.2f, 2.2f), Locations.Forest));
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
            
           switch (CurrenLocation)
           {
               case Locations.Village:
                   break;
               case Locations.Castle:
                   break;
               case Locations.Forest:
                    MusicManager.GetInstance().Skip();
                   break;
               case Locations.Home:
                   break;
               case Locations.Shop:
                   break;
               default:
                   Console.WriteLine("Error");
                   break;
           }
        }
       
    }
}
