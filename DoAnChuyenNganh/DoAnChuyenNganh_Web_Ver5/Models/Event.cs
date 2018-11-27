using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        public string EventTitle { get; set; }

        public DateTime StartDay { get; set; }

        public DateTime EndDay { get; set; }

        public string EventImg { get; set; }

        public string Content { get; set; }

    }
}