using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Funds4Kids.Models
{
    public class EventManager
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string PaypalAccountEmail { get; set; }

        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<EventInfo> EventInfos { get; set; }
    }
}