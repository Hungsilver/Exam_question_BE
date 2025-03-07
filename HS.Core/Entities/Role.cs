﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_question_BE.HS.Core.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar(12)")]
        public required string Name { get; set; }
    }
}
