using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCmsProject.Models.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    internal class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; } = null!;
        [Required]
        public int ErrandId { get; set; }
        public ErrandEntity Errands { get; set; } = null!;
        [Required]
        public int AddressId { get; set; }
        public AddressEntity Addresses { get; set; } = null!;
        [Required]
        public int CommentsId { get; set; }
        public CommentEntity Comments { get; set; } = null!;
    }
}
