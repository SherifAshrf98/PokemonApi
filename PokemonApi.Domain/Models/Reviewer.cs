﻿namespace PokemonReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
