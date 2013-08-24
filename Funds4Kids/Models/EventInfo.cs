using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Funds4Kids.Models
{
    public class EventInfo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Name { get; set; }

        [Required]
        [MaxLength(8000)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime CloseDate { get; set; }

        [Required]
        [Range(10, 10000)]
        [DataType(DataType.Currency)]
        public decimal Goal { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Denomination> Denominations { get; set; }

        public int EventCoordinatorId { get; set; }
        public virtual EventCoordinator EventCoordinator { get; set; }
    }
}