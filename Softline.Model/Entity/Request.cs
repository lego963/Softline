﻿using System;

namespace Softline.Model.Entity
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestAction { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
