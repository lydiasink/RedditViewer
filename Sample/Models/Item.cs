﻿using System;

namespace Sample.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        private Listing listing { get; set; }
    }
}