namespace chess_online.Models.SocialModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using UserModels;
    [NotMapped]
    public class Message
    {
        public Player Author { get; set; }

        [MaxLength(50)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
