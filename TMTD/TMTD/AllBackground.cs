using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace TMTD
{
    class AllBackground 
    {
        private static AllBackground instance;
        public static AllBackground GetInstance()
        {
            if (instance == null)
            {
                instance = new AllBackground();
            }
            return instance;
        }
        private Locations CurrenLocation;
        private List<Background> loadedBackground;
        private RenderWindow window;
        private Vector2f currentPosition;
        private View view;

        private AllBackground() 
        {
            loadedBackground = new List<Background>();
            loadedBackground.Add(new Background("Background/Sprites/Home/Home.jpg", new Vector2f (2.2f, 2.2f) ,Locations.Home));
            loadedBackground.Add(new Background("Background/Sprites/Forest/Bosque.jpg", new Vector2f(2.2f, 2.2f), Locations.Forest));
            loadedBackground.Add(new Background("Background/Sprites/Forest/Bosque.jpg", new Vector2f(2.2f, 2.2f), Locations.Castle));

        }
        public void UpdateBackground(Locations locations)
        {
            CurrenLocation = locations;
        }
        public void InitBackground(RenderWindow window) 
        {
            this.window = window;
            view = window.GetView();
            currentPosition = view.Center;
        }
        public void UpdateBackgroundPosition(Vector2f newCenter) 
        {
            view.Center = newCenter;
            window.SetView(view);
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
            
          
        }
       
    }
}
