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
        //Variables
        private bool toggle;
        private int count;
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

    }
}
