﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GameQueryDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Genre { get; set; }

        public double? RRP { get; set; }

        public string ImagePath { get; set; }

        public Boolean? isDeleted { get; set; }

    }
}