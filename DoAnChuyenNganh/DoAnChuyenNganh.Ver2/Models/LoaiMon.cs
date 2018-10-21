using DoAnChuyenNganh_Ver2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Ver2.Models
{
     [Table("LoaiMons")]
    public class LoaiMon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Maloai { get; set; }

        public string Tenloai { get; set; }

       
    }
}