using System.ComponentModel.DataAnnotations;

namespace HoteReservation.Web.Models.Season
{
    public class UpdateSeasonInputModel
    {
        [Display(Name ="Type")]
        [Required(ErrorMessage ="Type can't be Empty")]
        public string Type { get; set; }
    }
}
