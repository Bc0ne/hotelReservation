namespace HoteReservation.Web.Models.Season
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RoomRateInputModel
    {
        public long SeasonId { get; set; }
        [Display(Name = "Room Type")]
        public RoomRateOutputModel Room { get; set; }
        [Display(Name = "Room Rate")]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}
