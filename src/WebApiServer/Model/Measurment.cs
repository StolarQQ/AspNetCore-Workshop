using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiServer.Model
{
    public class Measurment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)"]
        public decimal Value { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        
        public Measurment(int id, string name, decimal value, string createdBy, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Value = value;
            CreatedBy = createdBy;
            CreatedAt = updatedAt;
        }



    }
}
