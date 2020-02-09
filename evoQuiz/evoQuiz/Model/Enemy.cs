﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace evoQuiz.Model
{
    public abstract class Enemy : Character
    {
        public Enemy(int X, int Y) : base(X, Y)
        {

        }
        public Enemy()
        {
            
        }

        public abstract void Ability(Player player);
    }
}
