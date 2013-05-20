﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Enemy {
        Texture2D texture;

        Vector2 pos;
        Vector2 gridPos;
        Vector2 speed;//Represents the change in the sprites position every tick
        int Xmultiplier, Ymultiplier;
        Grid grid;

        float layer;
        Rectangle rect;


        public Enemy(Vector2 gridPos, Grid grid, float Layer) {
            this.gridPos = gridPos;
            this.grid = grid;
            this.LockToGrid();
            this.layer = Layer;
        }
        public Enemy(Vector2 gridPos, Grid grid, float Layer, Vector2 speed) {
            this.gridPos = gridPos;
            this.grid = grid;
            this.LockToGrid();
            this.layer = Layer;
            this.speed = speed;

            this.Xmultiplier = -1;
            this.Ymultiplier = -1;
        }

        protected void LockToGrid() {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.X * this.grid.width; ;
            this.pos.Y = this.gridPos.Y * this.grid.height;
        }

        public void LoadContent(ContentManager content,String asset){
            this.texture=content.Load<Texture2D>(asset);
            this.getRect();
        }
        protected void getRect(){
            this.rect=new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        public void Update(GraphicsDevice graphics) {
            this.pos.X += this.speed.X * this.Xmultiplier;
            this.pos.Y += this.speed.Y * this.Ymultiplier;
            this.Bounding(graphics);
        }
        protected void Bounding(GraphicsDevice graphics) {
            if ((this.pos.X <= 0) || (this.pos.X >= graphics.Viewport.Width - this.texture.Width)) {
                this.Xmultiplier *= -1;
            }
            if ((this.pos.Y <= 0) || (this.pos.Y >= graphics.Viewport.Height - this.texture.Height)) {
                this.Ymultiplier *= -1;
            }
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spritebatch.Draw(this.texture, this.pos, null, Color.White, 0.0f, new Vector2(), 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}