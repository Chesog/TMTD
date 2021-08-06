using SFML.Graphics;
using SFML.System;
using System;
using System.IO;

namespace TMTD
{
    class Bullet : GameObjetBase , IColicionable
    {
        public Bullet(Vector2f position) : base ("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "Fire.png", position )
        {
            CollitionManager.Getinstance().addToColitionManeger(this);
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }
        public override void CheckGarbage()
        {
            
        }
        public override void DisposeNow()
        {
            CollitionManager.Getinstance().removeFromColitionManager(this);
            base.DisposeNow();
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

        public override void Update()
        {
            CurrentPosition.X += 50 * FrameRate.GetDeltaTime() ;
            base.Update();
        }
    }
}
