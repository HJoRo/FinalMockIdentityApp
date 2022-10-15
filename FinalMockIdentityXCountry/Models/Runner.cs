﻿using System.ComponentModel.DataAnnotations;

namespace FinalMockIdentityXCountry.Models
{
    public class Runner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string GetName => $"{FirstName} {LastName}";
    }
}
