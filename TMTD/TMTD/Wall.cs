using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SFML.System;

namespace TMTD
{
    class Wall : GameObjetBase, IColicionable
    {
        public Wall() : base ("WallSprites" + Path.DirectorySeparatorChar + "Woodwall.png" , new Vector2f(500.0f , 500.0f))
        {
           
            sprite.Scale = new Vector2f(0.2f, 1.0f);
            CollitionManager.Getinstance().addToColitionManeger(this);
        }

        public override void CheckGarbage()
        {
           
        }
        public override void DisposeNow()
        {
            CollitionManager.Getinstance().removeFromColitionManager(this);
            base.DisposeNow();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
        }
        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnColitionEnter(IColicionable other)
        {
           
        }

        public void OnColitionExit(IColicionable other)
        {
            
        }

        public void OnColitionStay(IColicionable other)
        {

        }
    }
}
