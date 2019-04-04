using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PingPongWebApplication.Models
{
    /// <summary>
    /// Represents players of ping pong table registered in the system
    /// </summary
    [Table("players")]
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string LastName { get; set; }


        public int? Age { get; set; }

        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        [Required]
        public string SkillLevel { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        public Players()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
    }
}
