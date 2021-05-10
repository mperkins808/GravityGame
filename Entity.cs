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
        public Entity(Texture2D texture, Vector2 pos, Vector2 velocity)
        {
            this.texture = texture;
            this.position = pos;
            x = position.X;
            y = position.Y;
            this.velocity = velocity;
            this.delete = false;
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
            this.velocity = v;
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
        private bool borderCheck()
        {
            Debug.WriteLine(this.x);
            if (this.x <= 0)
            {
                this.x = 0.01f;
                this.delete = true;
                return false;
            }
            else if (this.x >= WINDOW_WIDTH - texture.Width)
            {
                this.x = WINDOW_WIDTH - texture.Width - 0.01f;
                this.delete = true;
                Debug.WriteLine("DELETEPLZ");
                return false;
            }
            else if (this.y <= 0)
            {
                this.y = 0.01f;
                this.delete = true;
                return false;
            }
            else if (this.y >= WINDOW_HEIGHT - texture.Height)
            {
                this.y = WINDOW_HEIGHT - texture.Height - 0.01f;
                this.delete = true;
                return false;
            }
            else return true;
        }
        //Temp debugging functions
        //Called to update the position of the enity
        public void UpdatePos(float xVel, float yVel, GameTime gameTime)
        {
            if (borderCheck())
            {
                x += xVel * (float)gameTime.ElapsedGameTime.TotalSeconds;
                y += yVel * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
        public void changeColorOnMouseInput()
        {
            
        }
    }
}
