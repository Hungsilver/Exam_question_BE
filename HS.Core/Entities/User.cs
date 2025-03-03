using Exam_question_BE.HS.Core.Interfaces.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_question_BE.HS.Core.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [Column(TypeName = "varchar(8)")]
        public required string Code { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(TypeName = "varchar(16)")]
        public required string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public required string FullName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string? Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? Avatar { get; set; }
        public DateTime? BirthDate { get; set; }
        public required int Gender { get; set; } //nu - nam - gax
        [Column(TypeName = "varchar(11)")]
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? UpdatedBy { get; set; }
        public ICollection<Role> Roles { get; set; } = [];
    }
}
