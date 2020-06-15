using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace ChefsAndDishes.Models
{
    public class Wrapper
    {
        public List<Chef> AllChefs { get; set; }
        public List<Dish> AllDishes { get; set; }
        public Chef ChefForm { get; set; }
        public Dish DishForm { get; set; }
    }
}