namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<PokemonOwner> PokemonOwners { get; set; } = new HashSet<PokemonOwner>();
        public ICollection<PokemonCategory> PokemonCategories { get; set; } = new HashSet<PokemonCategory>();

    }
}
