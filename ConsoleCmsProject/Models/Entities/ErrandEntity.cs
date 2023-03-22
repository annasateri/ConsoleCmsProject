using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCmsProject.Models.Entities
{
    internal class ErrandEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ErrandTitle { get; set; } = null!;
        [StringLength(200)]
        public string Description { get; set; } = null!;
        [Column("created_at")]
        public DateTime CreatedAt = DateTime.Now;
        [StringLength(200)]
        public string? UpdateComment { get; set; } = null!;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();
        public ICollection<AddressEntity> Addresses { get; set; } = new HashSet<AddressEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
    }
}