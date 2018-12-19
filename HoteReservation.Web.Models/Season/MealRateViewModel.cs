using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HoteReservation.Web.Models.Season
{
    public class MealRateViewModel
    {
        public long MealId { get; set; }
        [Display(Name = "Meal Type")]
        public string MealType { get; set; }
        [Display(Name = "Meal Rate")]
        //[DataType(DataType.Currency)]
        public decimal Rate { get; set; }
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}
