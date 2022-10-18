using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewTask.Model
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(13)]
        [Required]
        public int Phone { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role RoleFK { get; set; }
    }
}
