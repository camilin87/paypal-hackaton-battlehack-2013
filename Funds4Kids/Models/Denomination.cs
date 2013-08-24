using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Funds4Kids.Models
{
    public class Denomination
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}