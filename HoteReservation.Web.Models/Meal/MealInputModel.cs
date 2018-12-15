namespace HoteReservation.Web.Models.Meal
{
    using System.ComponentModel.DataAnnotations;

    public class MealInputModel
    {
        [Display(Name = "Meal type")]
        [Required(ErrorMessage = "Meal type can't be empty")]
        [MinLength(5, ErrorMessage = "Meal Type can't be less than 5 characters")]
        public string Type { get; set; }
    }
}
