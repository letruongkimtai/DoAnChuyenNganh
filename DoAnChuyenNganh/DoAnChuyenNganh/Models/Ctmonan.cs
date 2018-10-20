using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh.Models
{
    [Table("CTMONAN")]
    public class Ctmonan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Mamon { get; set; }
        
        public  string Tenmon { get; set; }

        public  DateTime NgayBan { get; set; }

        public  decimal GiaBan { get; set; }

        public  string Anh { get; set; }

        public  string TrangThai { get; set; }

        public  string Mota { get; set; }


    }
}