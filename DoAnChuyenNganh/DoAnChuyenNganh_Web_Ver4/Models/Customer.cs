using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver4.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CtmID { get; set; }

        public string UserName { get; set; }

        public string Passwords { get; set; }

        public string CtmName { get; set; }

        public DateTime BDate { get; set; }

        public string Addr { get; set; }

        public int Tell { get; set; }

        public string Eaddr { get; set; }
    }
}