using System.ComponentModel.DataAnnotations;

namespace ReservationOrganiser.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        //Hotel
        public string OwnerId { get; set; }
        public int CalendarId { get; set; }

        public int Status { get; set; }

        public string Name { get; set; }
    }
}
