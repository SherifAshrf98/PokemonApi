namespace PokemonApi.Presentation.Helpers
{
    public class JwtConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
        public string Key { get; set; }
    }
}
