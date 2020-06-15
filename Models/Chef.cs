using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
namespace ChefsAndDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="First Name must contains 2 or more characters!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Last Name must contains 2 or more characters!")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        public List<Dish> CreatedDishes { get; set; }
        public DateTime CreatedAt { get;set; } = DateTime.Now;
        public DateTime UpdatedAt { get;set; } = DateTime.Now;

    }
}