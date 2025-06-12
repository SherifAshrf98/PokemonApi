using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PokemonApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fire" },
                    { 2, "Water" },
                    { 3, "Grass" },
                    { 4, "Electric" },
                    { 5, "Psychic" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kanto" },
                    { 2, "Johto" },
                    { 3, "Hoenn" },
                    { 4, "Sinnoh" },
                    { 5, "Unova" },
                    { 6, "Kalos" },
                    { 7, "Alola" },
                    { 8, "Galar" },
                    { 9, "Paldea" },
                    { 10, "Orre" }
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charizard" },
                    { 2, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blastoise" },
                    { 3, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venusaur" },
                    { 4, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pikachu" },
                    { 5, new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mewtwo" },
                    { 6, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snorlax" },
                    { 7, new DateTime(2020, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garchomp" },
                    { 8, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gengar" },
                    { 9, new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sylveon" },
                    { 10, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucario" }
                });

            migrationBuilder.InsertData(
                table: "Reviewers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Prof", "Oak" },
                    { 2, "Nurse", "Joy" },
                    { 3, "Giovanni", "Rocket" },
                    { 4, "Delia", "Ketchum" },
                    { 5, "Lance", "Dragon" },
                    { 6, "Lorelei", "Prima" },
                    { 7, "Bruno", "Elite" },
                    { 8, "Agatha", "Ghost" },
                    { 9, "Steven", "Stone" },
                    { 10, "Wallace", "Wave" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CountryId", "FirstName", "Gym", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Ash", "Pewter Gym", "Ketchum" },
                    { 2, 1, "Misty", "Cerulean Gym", "Waterflower" },
                    { 3, 1, "Brock", "Pewter Gym", "Harrison" },
                    { 4, 4, "Cynthia", "Sinnoh League", "Shirona" },
                    { 5, 6, "Serena", "Kalos Showcase", "Yvonne" },
                    { 6, 8, "Leon", "Galar League", "Crown" },
                    { 7, 4, "Dawn", "Sinnoh Contests", "Hikari" },
                    { 8, 3, "May", "Hoenn Contests", "Maple" },
                    { 9, 1, "Gary", "Pallet Town Lab", "Oak" },
                    { 10, 9, "Liko", "Paldea Academy", "Star" }
                });

            migrationBuilder.InsertData(
                table: "PokemonCategories",
                columns: new[] { "CategoryId", "PokemonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 5, 2 },
                    { 3, 3 },
                    { 5, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 3, 6 },
                    { 5, 6 },
                    { 3, 7 },
                    { 5, 7 },
                    { 5, 8 },
                    { 3, 9 },
                    { 5, 9 },
                    { 4, 10 },
                    { 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "PokemonId", "Rating", "ReviewerId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, 1, 5, 1, "Charizard is a powerhouse!", "Blazing Star" },
                    { 2, 1, 4, 2, "Incredible in battles!", "Fiery Champion" },
                    { 3, 1, 5, 3, "Charizard's flying is epic.", "Dragon Flame" },
                    { 4, 2, 4, 2, "Blastoise is unstoppable.", "Water Cannon" },
                    { 5, 3, 4, 3, "Venusaur is a tank!", "Grass Titan" },
                    { 6, 4, 5, 4, "Pikachu is adorable and strong!", "Electric Spark" },
                    { 7, 4, 5, 5, "Pikachu lights up the arena!", "Thunder Buddy" },
                    { 8, 4, 4, 6, "Pikachu's speed is unmatched.", "Shock Master" },
                    { 9, 5, 5, 5, "Mewtwo is terrifyingly powerful.", "Psychic Wonder" },
                    { 10, 6, 3, 6, "Snorlax blocks everything!", "Sleepy Giant" },
                    { 11, 7, 5, 7, "Garchomp is a beast!", "Dragon Power" }
                });

            migrationBuilder.InsertData(
                table: "PokemonOwners",
                columns: new[] { "OwnerId", "PokemonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 1 },
                    { 2, 2 },
                    { 9, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 6, 4 },
                    { 4, 5 },
                    { 9, 5 },
                    { 3, 6 },
                    { 7, 6 },
                    { 4, 7 },
                    { 5, 8 },
                    { 8, 8 },
                    { 5, 9 },
                    { 4, 10 },
                    { 10, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "PokemonCategories",
                keyColumns: new[] { "CategoryId", "PokemonId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "PokemonOwners",
                keyColumns: new[] { "OwnerId", "PokemonId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pokemons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
