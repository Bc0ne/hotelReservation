namespace HoteReservation.Web.Models.Room
{
    using System.ComponentModel.DataAnnotations;

    public class RoomInputModel
    {
        
        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Room type can't be empty")]
        [MinLength(5, ErrorMessage = "Room Type can't be less than 5 characters")]
        public string RoomType { get; set; }

        [Display(Name = "Number of Adults")]
        public int MaxNumOfAdults { get; set; }

        [Display(Name = "Number of Children")]
        public int MaxNumOfChildren { get; set; }
    }
}
