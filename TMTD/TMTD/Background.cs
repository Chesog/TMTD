using SFML.Graphics;
using SFML.System;
public enum Locations {Village , Castle , Forest , Home , Shop , Menu ,Error }

namespace TMTD
{
    public class Background
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f bacgrowndScale;
        private Locations name;
        public Background(string path, Vector2f scale, Locations name)
        {
            texture = new Texture(path);
            sprite = new Sprite(texture);
            bacgrowndScale = scale;
            this.name = name;
            sprite.Scale = bacgrowndScale;
        }
        public Background(string path, Vector2f scale) 
        {
            texture = new Texture(path);
            sprite = new Sprite(texture);
            bacgrowndScale = scale;
            sprite.Scale = bacgrowndScale;
        }
        public Sprite GetSprite()
        {
            return sprite;
        }
        public Locations GetLocationName()
        {
            return name;
        }
        public void Draw(RenderWindow window) 
        {
            window.Draw(sprite);
        }
    }
}