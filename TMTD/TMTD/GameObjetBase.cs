using SFML.Graphics;
using SFML.System;

namespace TMTD
{
    public abstract class GameObjetBase
    {
        protected Texture texture;
        protected Sprite sprite;
        protected Vector2f CurrentPosition;
        protected IntRect frameRect;
       
        public GameObjetBase(string TexturePath, Vector2f startposition)
        {
            texture = new Texture(TexturePath);
            sprite = new Sprite(texture);
            CurrentPosition = startposition;
            sprite.Position = CurrentPosition;
        }
        public virtual void Update() 
        {
            sprite.Position = CurrentPosition;

        }
        public virtual void Draw(RenderWindow window) 
        {
            window.Draw(sprite);
        }
        public void Dispose() 
        {
            sprite.Dispose();
            texture.Dispose();
        }
    }
}
