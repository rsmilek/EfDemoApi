﻿using System;
using System.Drawing;

namespace EfDemo.Domain.Entities
{
    public class Cover
    {
        public int CoverId { get; set; }

        public Color CoverColor { get; set; }

        // Complex type (new in EF8), NOTE: disadvantage of complex types is that they can't be optional :-(
        public Dimensions Dimensions { get; set; } = new();
    }
}
