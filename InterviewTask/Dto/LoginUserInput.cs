using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Dto
{
    public class LoginUserInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
