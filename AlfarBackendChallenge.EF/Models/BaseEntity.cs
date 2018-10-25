using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfarBackendChallenge.EF.Models
{

    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreationTimeStamp { get; set; }

        public DateTime? LastModificationTimeStamp { get; set; }
    }
}
