﻿using DoAnPaint.Graphs.Core.Interfaces;
using System;

namespace DoAnPaint.Graphs.Models.NinthQuestion
{
    internal class FirstModel : IModel
    {
        public string Name => "y = 1/(2sqrt(2pi))*exp(-0.35x^2)";

        public double Calculate(double x)
        {
            return 1 / (2 * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.35 * Math.Pow(x, 2));
        }


    }
}
