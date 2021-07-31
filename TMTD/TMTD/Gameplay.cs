using SFML.Graphics;

namespace TMTD
{
    class Gameplay
    {
        private Player player;
        private AllBackground background;
        public Gameplay() 
        {
            player = new Player("Max",1000,100,0,100, Locations.Home);
            background = new AllBackground(player);
        }
        public void UpdateGameplay() 
        {
            player.Update();
            background.UpdateBackground(player);
        }
        public void DrawGameplay(RenderWindow window) 
        {
            background.DrawBackground(window);
            player.Draw(window);
        }
    }
}
