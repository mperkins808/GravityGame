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

        //WINDOW SIZE
        const float WINDOW_WIDTH = 1280;
        const float WINDOW_HEIGHT = 720;
        //MAGIC NUMBERS TO REMOVE
        const float BUFFER = 50;
        public Entity(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.position = pos;
            x = position.X;
            y = position.Y;
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
            return new Vector2(x, y);
        }

        public float GetX()
        {
            return this.x;
        }
        public void SetX(float x)
        {
            this.x = x;
            this.position.X = x;
        }
        public float GetY()
        {
            return this.y;
        }
        public void SetY(float y)
        {
            this.y = y;
            this.position.Y = y;
        }

        private bool borderCheck()
        {
            Debug.WriteLine(this.x);
            if (this.x <= 0)
            {
                this.x = 0.01f;
                return false;
            }
            else if (this.x >= WINDOW_WIDTH - texture.Width)
            {
                this.x = WINDOW_WIDTH - texture.Width - 0.01f;
                return false;
            }
            else if (this.y <= 0)
            {
                this.y = 0.01f;
                return false;
            }
            else if (this.y >= WINDOW_HEIGHT - texture.Height)
            {
                this.y = WINDOW_HEIGHT - texture.Height - 0.01f;
                return false;
            }
            else return true;
        }
        //Temp debugging functions
        public void UpdatePos(float xVel, float yVel, GameTime gameTime)
        {
            if (borderCheck())
            {
                x += xVel * (float)gameTime.ElapsedGameTime.TotalSeconds;
                y += yVel * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        //Captures Mouse input and changes color of circle
        public void changeColorOnMouseInput()
        {
            
        }
    }
}
