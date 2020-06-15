using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace ChefsAndDishes.Models
{
    public class Dish
    {
    [Key]
    public int DishId { get; set; }
    
    [Required(ErrorMessage="You forgot the name!")]
    [MinLength(2, ErrorMessage="Please provide 2 or more characters.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage="You forgot to rate it!")]
    [Range(1,5)]
    public int? Tastiness { get; set; }
    
    [Required]
    [Range(1,double.PositiveInfinity, ErrorMessage="Nothing really has zero calories.")]
    public int? Calories { get; set; }

    [Required(ErrorMessage="Please give us some idea of what this dish is!")]
    public string Description { get; set; }
    public int ChefId { get; set; }
    public Chef Creator { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}