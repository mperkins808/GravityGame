using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GravityGame
{
    class Physics
    {
        List<Entity> entityList;
        private GraphicsDeviceManager _graphics;

        //WINDOW SIZE 
        const float WINDOW_WIDTH = 1280;
        const float WINDOW_HEIGHT = 720;
        //MAGIC NUMBERS TO REMOVE
        const float BUFFER = 50;
        //COSTANTS
        const int TIMER = 60;

        const double MASS = 15;
        //Variables
        private bool toggle;
        private int count;
        private Vector2[] forceVector;

        public struct Distance  
        {
            public double X;
            public double Y;
        }
        public Physics(List<Entity> entities)
        {
            this.entityList = new List<Entity>();
            this.entityList = entities;

        }
        public Physics(Entity entity)
        {
            this.entityList = new List<Entity>();
            this.entityList.Add(entity);
        }
        public Physics() 
        {
            this.entityList = new List<Entity>();
        }

        public List<Entity> getEntityList()
        {
            initialG();
            return entityList;
        }

        public void addToList(Entity entity)
        {
            this.entityList.Add(entity);
        }
        private void Initialisation()
        {
            _graphics.PreferredBackBufferWidth = (int)WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = (int)WINDOW_HEIGHT;

            toggle = true;
            count = 0;
        }

        private void initialG()
        {
            Distance[] distance = new Distance[2];
            Vector2 posCheck = new Vector2();
            forceVector = new Vector2[2];
            if (entityList.Count >= 2)
            {
                posCheck.X = entityList[0].GetPosition().X - entityList[1].GetPosition().X;
                posCheck.Y = entityList[0].GetPosition().Y - entityList[1].GetPosition().Y;
                distance[0].X = (entityList[0].GetPosition().X - entityList[1].GetPosition().X) * (entityList[0].GetPosition().X - entityList[1].GetPosition().X);
                distance[0].Y = (entityList[0].GetPosition().Y - entityList[1].GetPosition().Y) * (entityList[0].GetPosition().Y - entityList[1].GetPosition().Y);
                forceVector[0] = new Vector2((float)(((MASS * MASS) / distance[0].X)), (float)(((MASS * MASS) / distance[0].Y)));
                if (distance[0].X > entityList[0].GetTexture().Width && distance[0].Y! > entityList[0].GetTexture().Height)
                {
                    if (posCheck.X > 0 && posCheck.Y < 0)
                    {
                        forceVector[0] = new Vector2((float)(((MASS * MASS) / distance[0].X)), -1 * (float)(((MASS * MASS) / distance[0].Y)));
                    }
                    else if (posCheck.X < 0 && posCheck.Y > 0)
                    {
                        forceVector[0] = new Vector2(-1 * (float)(((MASS * MASS) / distance[0].X)), (float)(((MASS * MASS) / distance[0].Y)));
                    }
                    else if (posCheck.X < 0 && posCheck.Y < 0)
                    {
                        forceVector[0] = new Vector2(-1 * (float)(((MASS * MASS) / distance[0].X)),-1 * (float)(((MASS * MASS) / distance[0].Y)));
                    }
                    entityList[1].SetVelocty(forceVector[0]);

                }
                Debug.WriteLine("X FORCE: " + forceVector[0].X.ToString() + "Y FORCE: " + forceVector[0].Y.ToString() + "X VEL: " + entityList[1].GetVelocity().X);
            }
        }

    }
}
