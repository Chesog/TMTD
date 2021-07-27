using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace TMTD
{
    class Player : GameObjetBase
    {      
        private int sheetColums = 10;
        private int sheetRows = 9;
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
        private float GravitySpeed;
        public int TextureXSize;
        public int TextureYSize;
        public Player() : base("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement.png", new Vector2f(0.0f, 0.0f))
        {

        }
        public Player(string Name , int MaxLife , int MaxMana ,  int MinAttk , int MaxAttk , Locations spawnpoint) : base ("Player" + Path.DirectorySeparatorChar + "Sprites" + Path.DirectorySeparatorChar + "PlayerAnimations" + Path.DirectorySeparatorChar + "PlayerMovement.png" , new Vector2f(0.0f, 0.0f), new IntRect(0,0,1000 ,495)
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
            frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColums, (int)texture.Size.Y / sheetRows);
            TextureXSize = (int)texture.Size.X / sheetColums;
            TextureYSize = (int)texture.Size.Y / sheetRows;
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            speed = 250.0f;
            RateOfFire = 1.0f;
            GravitySpeed = 3.0f;
        }
        public override void Update()
        {
            Movement();
            Atakk();
            Gravity();
            base.Update();
       
        }
        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw(window);
                }
            }
        }
        private void Movement() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                CurrentPosition.X += speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                CurrentPosition.X -= speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                CurrentPosition.Y -= speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                CurrentPosition.Y += speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                CurrentPosition.Y -= speed * FrameRate.GetDeltaTime();
            }
            
        }
        private void Gravity() 
        {
            CurrentPosition.Y += GravitySpeed * FrameRate.GetDeltaTime();
            GravitySpeed += 0.02f;
        }
        private void Atakk() 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.K))
            {
                
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.L))
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
        public void RestPlayer() { }


    }
}

