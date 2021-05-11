using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GravityGame
{
    class Entity
    {
        private Texture2D texture;
        private Vector2 position;
        private float x, y;
        private Vector2 velocity;
        private bool delete;

        //WINDOW SIZE
        const float WINDOW_WIDTH = 1280;
        const float WINDOW_HEIGHT = 720;
        //MAGIC NUMBERS TO REMOVE
        const float BUFFER = 50;
        private int i;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;
        public Entity(Texture2D texture, Vector2 pos, Vector2 velocity)
        {
            this.texture = texture;
            this.position = pos;
            x = position.X;
            y = position.Y;
            this.velocity = velocity;
            this.delete = false;
            i = 0;
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        public Texture2D GetTexture()
        {
            return this.texture;
        }
        public void SetPosition(Vector2 pos)
        {
            this.position = pos;
        }
        public Vector2 GetPosition()
        {
            return this.position;
        }
        public void SetVelocty(Vector2 v)
        {
            this.velocity += v;
        }
        public Vector2 GetVelocity()
        {
            return this.velocity;
        }
        public float GetX()
        {
            CheckToDelete();
            return this.x;
        }
        public void SetX(float x)
        {
            CheckToDelete();
            this.x = x;
            this.position.X = x;
        }
        public float GetY()
        {
            CheckToDelete();
            return this.y;
        }
        public void SetY(float y)
        {
            CheckToDelete();
            this.y = y;
            this.position.Y = y;
        }
        public void SetDelete(bool set)
        {
            this.delete = set;
        }
        public bool GetDelete()
        {
            return this.delete;
        }

        //Temp debugging functions
        //Called to update the position of the enity
        public void UpdatePos(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (!this.delete)
            {
                SetX(this.x + (GetVelocity().X * (float)gameTime.ElapsedGameTime.TotalSeconds));
                SetY(this.y + (GetVelocity().Y * (float)gameTime.ElapsedGameTime.TotalSeconds));
            }
        }
       
        public void CheckToDelete()
        {
            if (this.x > WINDOW_WIDTH || this.x < 0 - this.texture.Width || this.y > WINDOW_HEIGHT|| this.y < 0 - this.texture.Height)
            {
                this.delete = true;
            }
        }

        //Captures Mouse input and changes color of circle
        public String animations()
        {
            string[] sprites = TexturePackerMonoGameDefinitions.earthSprites.getSprites();
            while (i < sprites.Length)
            {
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    i++;
                }
                if (i == sprites.Length)
                {
                    i = 0;
                    return sprites[sprites.Length - 1];
                }
                return sprites[i];
            }
            return "bug";
        }
    }
}
