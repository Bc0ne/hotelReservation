namespace HoteReservation.Web.Models.Room
{
    using System.ComponentModel.DataAnnotations;

    public class RoomViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Room type")]
        [Required(ErrorMessage = "Room type can't be empty")]
        [MinLength(5, ErrorMessage = "Room Type can't be less than 5 characters")]
        public string RoomType { get; set; }
        [Display(Name = "Room capacity for adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Room capacity for children")]
        public int NumberOfChildren { get; set; }
    }
}
