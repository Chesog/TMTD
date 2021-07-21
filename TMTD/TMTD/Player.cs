using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TMTD
{
    class Player
    {
        private Sprite sprite;
        private Texture texture;
        private IntRect frameRect;
        private int sheetColums = 10;
        private int sheetRows = 9;
        public Vector2f position;
        private float speed;
        public List<Bullet> bullets;
        private float Timer;
        private float RateOfFire;
        private string Name;
        private int MaxLife;
        private int Life;
        private int MaxMana;
        private int Mana;
        private int MinAtkk;
        private int MaxAttk;
        private Locations location;
        public Player()
        {

        }
        public Player(string Name , int MaxLife , int MaxMana ,  int MinAttk , int MaxAttk , Locations spawnpoint) 
        {
            this.Name = Name;
            this.MaxLife = MaxLife;
            this.Life = MaxLife;
            this.MaxMana = MaxMana;
            this.MinAtkk = MinAttk;
            this.MaxAttk = MaxAttk;
            this.Mana = MaxMana;

            location = spawnpoint;
            bullets = new List<Bullet>();
            texture = new Texture("Player/Sprites/PlayerAnimations/PlayerMovement.png");
            frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColums, (int)texture.Size.Y / sheetRows);
            sprite = new Sprite(texture, frameRect);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
            speed = 250.0f;
            RateOfFire = 1.0f;
        }

        public void UpdatePlayer()
        {
            Movement();
            Atakk();
        }
        private void Movement() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                position.X += (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                position.X -= (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                position.Y -= (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                position.Y += (speed * (1.0f / (float)Game.FRAMERATE_LIMIT));
            }
        }
        private void Atakk() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.J))
            {

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.K))
            {

            }
        }
        public void HealPlayer() 
        {
            Life = MaxLife;
        }
        public void HealPlayer(int Amount) 
        {
            Life += Amount;
            if (Life > MaxLife)
            {
                Life = MaxLife;
            }
        }
        public void RestoreMana() 
        {
            Mana = MaxMana;
        }
        public void RestoreMana(int Amount)
        {
            Mana += Amount;
            if (Mana > MaxMana)
            {
                Mana = MaxMana;
            }
        }
        public Locations GetLocations() 
        {
            return location;
        }
        public void GoToShop() 
        {
            location = Locations.Shop;
        }
        public void GoToVillage()
        {
            location = Locations.Village;
        }
        public void GoToForest()
        {
            location = Locations.Forest;
        }
        public void GoToHome()
        {
            location = Locations.Home;
        }
        public void GoToCastle()
        {
            location = Locations.Castle;
        }
        public void DrawPlayer(RenderWindow window)
        {
            window.Draw(sprite);
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw(window);
                }
            }
        }
        public void RestPlayer() { }
    }
}

