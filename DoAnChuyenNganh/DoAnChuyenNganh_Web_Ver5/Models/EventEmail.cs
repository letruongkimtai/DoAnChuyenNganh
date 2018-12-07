using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Table("EventEmails")]
    public class EventEmail
    {
        [Key]
        public string Email { get; set; }
    }
}