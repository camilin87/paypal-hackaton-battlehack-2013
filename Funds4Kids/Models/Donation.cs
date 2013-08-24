using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Funds4Kids.Models
{
    public class Donation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [ScaffoldColumn(false)]
        public DateTime Timestamp { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string SenderEmail { get; set; }

        public int EventInfoId { get; set; }
        public virtual EventInfo EventInfo { get; set; }
    }
}