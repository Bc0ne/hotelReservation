using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HoteReservation.Web.Models.Reservation
{
    public class ReservationInputModel
    {
        [Required(ErrorMessage ="Name can't be empty")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Country can't be empty")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Number of Adults can't be empty")]
        public int Adults { get; set; }

        [Required(ErrorMessage = "Number of Children can't be empty")]
        public int Children { get; set; }

        [Display(Name ="Room Type")]
        public long RoomId { get; set; }

        [Display(Name = "Meal Type")]
        public long MealId { get; set; }

        [Display(Name ="Check-in")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-out")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }
    }
}
