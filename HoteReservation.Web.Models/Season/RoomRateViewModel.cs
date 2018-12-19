namespace HoteReservation.Web.Models.Season
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RoomRateViewModel
    {
        public long RateId { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        public string SeasonType { get; set; }
        [Display(Name = "Room Rate")]
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
