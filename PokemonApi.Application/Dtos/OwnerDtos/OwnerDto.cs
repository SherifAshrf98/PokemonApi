﻿using PokemonReviewApp.Models;

namespace PokemonApi.Application.Dtos.OwnerDtos
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public string CountryName { get; set; }
    }
}