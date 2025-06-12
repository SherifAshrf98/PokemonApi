using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApi.Infrastructure.Data
{
    public static class SeedData
    {
        public static void ApplySeedData(ModelBuilder modelBuilder)
        {
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Kanto" },
                new Country { Id = 2, Name = "Johto" },
                new Country { Id = 3, Name = "Hoenn" },
                new Country { Id = 4, Name = "Sinnoh" },
                new Country { Id = 5, Name = "Unova" },
                new Country { Id = 6, Name = "Kalos" },
                new Country { Id = 7, Name = "Alola" },
                new Country { Id = 8, Name = "Galar" },
                new Country { Id = 9, Name = "Paldea" },
                new Country { Id = 10, Name = "Orre" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Fire" },
                new Category { Id = 2, Name = "Water" },
                new Category { Id = 3, Name = "Grass" },
                new Category { Id = 4, Name = "Electric" },
                new Category { Id = 5, Name = "Psychic" }
            );

            // Seed Pokemons
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon { Id = 1, Name = "Charizard", BirthDate = new DateTime(2020, 1, 15) },
                new Pokemon { Id = 2, Name = "Blastoise", BirthDate = new DateTime(2020, 2, 20) },
                new Pokemon { Id = 3, Name = "Venusaur", BirthDate = new DateTime(2020, 3, 10) },
                new Pokemon { Id = 4, Name = "Pikachu", BirthDate = new DateTime(2021, 4, 5) },
                new Pokemon { Id = 5, Name = "Mewtwo", BirthDate = new DateTime(2019, 5, 12) },
                new Pokemon { Id = 6, Name = "Snorlax", BirthDate = new DateTime(2021, 6, 25) },
                new Pokemon { Id = 7, Name = "Garchomp", BirthDate = new DateTime(2020, 7, 30) },
                new Pokemon { Id = 8, Name = "Gengar", BirthDate = new DateTime(2021, 8, 15) },
                new Pokemon { Id = 9, Name = "Sylveon", BirthDate = new DateTime(2022, 9, 10) },
                new Pokemon { Id = 10, Name = "Lucario", BirthDate = new DateTime(2022, 10, 20) }
            );

            // Seed Owners
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, FirstName = "Ash", LastName = "Ketchum", Gym = "Pewter Gym", CountryId = 1 },
                new Owner { Id = 2, FirstName = "Misty", LastName = "Waterflower", Gym = "Cerulean Gym", CountryId = 1 },
                new Owner { Id = 3, FirstName = "Brock", LastName = "Harrison", Gym = "Pewter Gym", CountryId = 1 },
                new Owner { Id = 4, FirstName = "Cynthia", LastName = "Shirona", Gym = "Sinnoh League", CountryId = 4 },
                new Owner { Id = 5, FirstName = "Serena", LastName = "Yvonne", Gym = "Kalos Showcase", CountryId = 6 },
                new Owner { Id = 6, FirstName = "Leon", LastName = "Crown", Gym = "Galar League", CountryId = 8 },
                new Owner { Id = 7, FirstName = "Dawn", LastName = "Hikari", Gym = "Sinnoh Contests", CountryId = 4 },
                new Owner { Id = 8, FirstName = "May", LastName = "Maple", Gym = "Hoenn Contests", CountryId = 3 },
                new Owner { Id = 9, FirstName = "Gary", LastName = "Oak", Gym = "Pallet Town Lab", CountryId = 1 },
                new Owner { Id = 10, FirstName = "Liko", LastName = "Star", Gym = "Paldea Academy", CountryId = 9 }
            );

            // Seed Reviewers
            modelBuilder.Entity<Reviewer>().HasData(
                new Reviewer { Id = 1, FirstName = "Prof", LastName = "Oak" },
                new Reviewer { Id = 2, FirstName = "Nurse", LastName = "Joy" },
                new Reviewer { Id = 3, FirstName = "Giovanni", LastName = "Rocket" },
                new Reviewer { Id = 4, FirstName = "Delia", LastName = "Ketchum" },
                new Reviewer { Id = 5, FirstName = "Lance", LastName = "Dragon" },
                new Reviewer { Id = 6, FirstName = "Lorelei", LastName = "Prima" },
                new Reviewer { Id = 7, FirstName = "Bruno", LastName = "Elite" },
                new Reviewer { Id = 8, FirstName = "Agatha", LastName = "Ghost" },
                new Reviewer { Id = 9, FirstName = "Steven", LastName = "Stone" },
                new Reviewer { Id = 10, FirstName = "Wallace", LastName = "Wave" }
            );

            // Seed PokemonCategories
            modelBuilder.Entity<PokemonCategory>().HasData(
                 new PokemonCategory { PokemonId = 1, CategoryId = 1 }, // Charizard - Fire
                 new PokemonCategory { PokemonId = 1, CategoryId = 5 }, // Charizard - Psychic (reflecting its intense willpower and Mega forms)
                 new PokemonCategory { PokemonId = 2, CategoryId = 2 }, // Blastoise - Water
                 new PokemonCategory { PokemonId = 2, CategoryId = 5 }, // Blastoise - Psychic (reflecting its strategic battle style)
                 new PokemonCategory { PokemonId = 3, CategoryId = 3 }, // Venusaur - Grass
                 new PokemonCategory { PokemonId = 3, CategoryId = 5 }, // Venusaur - Psychic (reflecting its mystical plant abilities)
                 new PokemonCategory { PokemonId = 4, CategoryId = 4 }, // Pikachu - Electric
                 new PokemonCategory { PokemonId = 5, CategoryId = 5 }, // Mewtwo - Psychic
                 new PokemonCategory { PokemonId = 6, CategoryId = 5 }, // Snorlax - Psychic (reflecting its calm, meditative nature)
                 new PokemonCategory { PokemonId = 6, CategoryId = 3 }, // Snorlax - Grass (reflecting its connection to nature and bulk)
                 new PokemonCategory { PokemonId = 7, CategoryId = 5 }, // Garchomp - Psychic (reflecting its fierce battle instincts)
                 new PokemonCategory { PokemonId = 7, CategoryId = 3 }, // Garchomp - Grass (reflecting its ground-based, earthy nature)
                 new PokemonCategory { PokemonId = 8, CategoryId = 5 }, // Gengar - Psychic (reflecting its ghostly, mind-affecting abilities)
                 new PokemonCategory { PokemonId = 9, CategoryId = 5 }, // Sylveon - Psychic (reflecting its mystical, charming nature)
                 new PokemonCategory { PokemonId = 9, CategoryId = 3 }, // Sylveon - Grass (reflecting its connection to nature via Eevee’s origins)
                 new PokemonCategory { PokemonId = 10, CategoryId = 5 }, // Lucario - Psychic (reflecting its aura-based abilities)
                 new PokemonCategory { PokemonId = 10, CategoryId = 4 }  // Lucario - Electric (reflecting its energy-based aura attacks)
             );

            // Seed PokemonOwners
            modelBuilder.Entity<PokemonOwner>().HasData(
                 new PokemonOwner { PokemonId = 1, OwnerId = 1 }, // Charizard - Ash
                 new PokemonOwner { PokemonId = 1, OwnerId = 6 }, // Charizard - Leon
                 new PokemonOwner { PokemonId = 2, OwnerId = 2 }, // Blastoise - Misty
                 new PokemonOwner { PokemonId = 2, OwnerId = 9 }, // Blastoise - Gary
                 new PokemonOwner { PokemonId = 3, OwnerId = 3 }, // Venusaur - Brock
                 new PokemonOwner { PokemonId = 4, OwnerId = 1 }, // Pikachu - Ash
                 new PokemonOwner { PokemonId = 4, OwnerId = 6 }, // Pikachu - Leon
                 new PokemonOwner { PokemonId = 5, OwnerId = 9 }, // Mewtwo - Gary
                 new PokemonOwner { PokemonId = 5, OwnerId = 4 }, // Mewtwo - Cynthia
                 new PokemonOwner { PokemonId = 6, OwnerId = 7 }, // Snorlax - Dawn
                 new PokemonOwner { PokemonId = 6, OwnerId = 3 }, // Snorlax - Brock
                 new PokemonOwner { PokemonId = 7, OwnerId = 4 }, // Garchomp - Cynthia
                 new PokemonOwner { PokemonId = 8, OwnerId = 8 }, // Gengar - May
                 new PokemonOwner { PokemonId = 8, OwnerId = 5 }, // Gengar - Serena
                 new PokemonOwner { PokemonId = 9, OwnerId = 5 }, // Sylveon - Serena
                 new PokemonOwner { PokemonId = 10, OwnerId = 10 }, // Lucario - Liko
                 new PokemonOwner { PokemonId = 10, OwnerId = 4 }  // Lucario - Cynthia
             );

            // Seed Reviews 
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Title = "Blazing Star", Text = "Charizard is a powerhouse!", Rating = 5, PokemonId = 1, ReviewerId = 1 },
                new Review { Id = 2, Title = "Fiery Champion", Text = "Incredible in battles!", Rating = 4, PokemonId = 1, ReviewerId = 2 },
                new Review { Id = 3, Title = "Dragon Flame", Text = "Charizard's flying is epic.", Rating = 5, PokemonId = 1, ReviewerId = 3 },
                new Review { Id = 4, Title = "Water Cannon", Text = "Blastoise is unstoppable.", Rating = 4, PokemonId = 2, ReviewerId = 2 },
                new Review { Id = 5, Title = "Grass Titan", Text = "Venusaur is a tank!", Rating = 4, PokemonId = 3, ReviewerId = 3 },
                new Review { Id = 6, Title = "Electric Spark", Text = "Pikachu is adorable and strong!", Rating = 5, PokemonId = 4, ReviewerId = 4 },
                new Review { Id = 7, Title = "Thunder Buddy", Text = "Pikachu lights up the arena!", Rating = 5, PokemonId = 4, ReviewerId = 5 },
                new Review { Id = 8, Title = "Shock Master", Text = "Pikachu's speed is unmatched.", Rating = 4, PokemonId = 4, ReviewerId = 6 },
                new Review { Id = 9, Title = "Psychic Wonder", Text = "Mewtwo is terrifyingly powerful.", Rating = 5, PokemonId = 5, ReviewerId = 5 },
                new Review { Id = 10, Title = "Sleepy Giant", Text = "Snorlax blocks everything!", Rating = 3, PokemonId = 6, ReviewerId = 6 },
                new Review { Id = 11, Title = "Dragon Power", Text = "Garchomp is a beast!", Rating = 5, PokemonId = 7, ReviewerId = 7 }
            );
        }
    }
}
