namespace chess_online.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WelcomeViewModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(6)]
        public string NickName { get; set; }       
    }
}
