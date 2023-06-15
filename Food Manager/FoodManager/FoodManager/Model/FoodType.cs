﻿using System.ComponentModel.DataAnnotations;

namespace FoodManager.Model
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
