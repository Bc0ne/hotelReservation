using System.ComponentModel.DataAnnotations;

namespace HoteReservation.Web.Models.Season
{
    public class RoomRateUpdateInputModel
    {
        public long RoomRateId { get; set; }

        public long SeasonId { get; set; }

        [Display(Name = "Room Rate")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
    }
}
