using System.ComponentModel.DataAnnotations;

namespace api_university.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassWord { get; set; }

    }
}
