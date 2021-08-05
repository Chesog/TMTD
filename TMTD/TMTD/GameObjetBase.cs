using SFML.Graphics;
using SFML.System;

namespace TMTD
{
    public abstract class GameObjetBase
    {
        protected Texture texture;
        protected Sprite sprite;
        protected Vector2f CurrentPosition;
        public bool toDelelte;
        public bool lateDispose;
       
        public GameObjetBase(string TexturePath, Vector2f startposition)
        {
            texture = new Texture(TexturePath);
            sprite = new Sprite(texture);
            CurrentPosition = startposition;
            sprite.Position = CurrentPosition;
            toDelelte = false;
            lateDispose = false;
        }
        public virtual void Update() 
        {
            sprite.Position = CurrentPosition;

        }
        public virtual void Draw(RenderWindow window) 
        {
            window.Draw(sprite);
        }
        public virtual void DisposeNow() 
        {
            sprite.Dispose();
            texture.Dispose();
            toDelelte = true;
        }
        public void LateDispose() 
        {
            lateDispose = true;
        }
        public virtual void CheckGarbage() 
        {
            if (lateDispose == true)
            {
                DisposeNow();
            }
        }
        public Vector2f GetPosition() 
        {
            return CurrentPosition;
        }
    }
}
