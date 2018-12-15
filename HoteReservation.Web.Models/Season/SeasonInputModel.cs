namespace HoteReservation.Web.Models.Season
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SeasonInputModel
    {

        [Display(Name = "Season type")]
        [Required(ErrorMessage = "Season type can't be empty")]
        [MinLength(3, ErrorMessage = "Room Type can't be less than 3 characters")]
        public string SeasonType { get; set; }
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }
    }
}
