using AlfarBackendChallenge.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlfarBackendChallenge.Web.ViewModels
{
    public class CustomerViewModel
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
        public AddressViewModel Address { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public CustomerViewModel()
        {

        }
    }
}