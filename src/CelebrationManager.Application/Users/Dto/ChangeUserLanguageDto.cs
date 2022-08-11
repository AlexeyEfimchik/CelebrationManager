using System.ComponentModel.DataAnnotations;

namespace CelebrationManager.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}