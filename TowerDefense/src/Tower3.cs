﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense.src {
    class Tower3 : Tower {
        //needs to not rotate
        public Tower3(Vector2 gridPos, Grid grid,float layer)
            : base(gridPos, grid,layer) {
            this.asset = "Tower3";
            this.target = GV.EnemyList[0];//Tower target
            this.damage = 25;
            this.cost = 125;
            this.angle = 0;
            this.LoadContent(GV.content);
        }
    }
}
