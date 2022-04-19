﻿namespace Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
