﻿namespace PokemonReviewApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Owner> Owners { get; set; } = new HashSet<Owner>();
    }
}
