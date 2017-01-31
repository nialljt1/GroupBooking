using Api.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Email
    {
        public Email()
        {
            Created = DateTimeOffset.Now;
        }

        public string Bcc { get; set; }

        public string Body { get; set; }

        public string Cc { get; set; }

        public DateTimeOffset Created { get; set; }

        [Required]
        public string From { get; set; }

        public int Id { get; set; }

        public DateTimeOffset? Sent { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string To { get; set; }
    }
}
