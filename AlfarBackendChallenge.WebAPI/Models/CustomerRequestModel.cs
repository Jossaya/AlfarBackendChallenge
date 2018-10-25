using System;
using System.ComponentModel.DataAnnotations;

namespace AlfarBackendChallenge.WebAPI.Models
{
    public class CustomerRequestModel
    {
        public Guid Id { get; set; }
        public DateTime LastModificationDate { get; set; }
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
        public Guid AddressId { get; set; }
        [Required]
        public DateTime CreationTimeStamp { get; set; }
        public DateTime? LastModificationTimeStamp { get; set; }   
        public AddressRequestModel Address { get; set; }
    }
}