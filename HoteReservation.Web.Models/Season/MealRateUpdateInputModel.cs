namespace HoteReservation.Web.Models.Season
{
    using System.ComponentModel.DataAnnotations;

    public class MealRateUpdateInputModel
    {
        public long MealRateId { get; set; }

        public long SeasonId { get; set; }

        [Display(Name = "Room Rate")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}
