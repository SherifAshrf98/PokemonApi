namespace PokemonReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public Pokemon Pokemon { get; set; }
        public int PokemonId { get; set; } //Foreign Key
        public Reviewer Reviewer { get; set; }
        public int ReviewerId { get; set; } //Foreign Key
    }
}
