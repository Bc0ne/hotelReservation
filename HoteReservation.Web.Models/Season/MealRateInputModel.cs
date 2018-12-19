using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HoteReservation.Web.Models.Season
{
    public class MealRateInputModel
    {
        public long SeasonId { get; set; }
        [Display(Name = "Meal Type")]
        public long MealId { get; set; }
        [Display(Name = "Meal Rate")]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}
