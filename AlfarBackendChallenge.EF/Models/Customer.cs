using System;
using System.ComponentModel.DataAnnotations;

namespace AlfarBackendChallenge.EF.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string PreferredName { get; set; }
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Biography { get; set; }
        public string JobTitle { get; set; }
        public Address Address { get; set; }
    }
}
