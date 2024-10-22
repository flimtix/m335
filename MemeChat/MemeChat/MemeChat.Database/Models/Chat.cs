﻿using System.ComponentModel.DataAnnotations;

namespace MemeChat.Models
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public User User_1 { get; set; }
        [Required]
        public User User_2 { get; set; }
        public virtual List<Message> Messages { get; set; } = new List<Message>();

        public Chat Clone()
        {
            return new Chat()
            {
                User_1 = User_1,
                User_2 = User_2,
                Messages = Messages
            };
        }
    }
}
