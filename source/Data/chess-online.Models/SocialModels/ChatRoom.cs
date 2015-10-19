namespace chess_online.Models.SocialModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string LanguageCode { get; set; }

        [NotMapped]
        public List<Message> messages { get; set; }

    }
}
