using System;
using System.ComponentModel.DataAnnotations;

namespace AlfarBackendChallenge.WebAPI.Models
{
    public class AddressRequestModel
    {
        public Guid Id { get; set; }
         public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Required]
        public DateTime CreationTimeStamp { get; set; }
        public DateTime? LastModificationTimeStamp { get; set; }
    }
}