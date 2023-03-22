﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCmsProject.Models.Entities
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string SteetName { get; set; } = null!;
        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;
        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();
    }
}