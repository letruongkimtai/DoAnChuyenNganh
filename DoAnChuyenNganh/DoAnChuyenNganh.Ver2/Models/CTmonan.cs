using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Ver2.Models
{
    [Table("CTmonans")]
    public class CTmonan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Set ID run auto
        public int Mamon { get; set; }

        public string Tenmon { get; set; }

        public DateTime? Ngayban { get; set; }

        public decimal Giaban { get; set; }

        public string Anh { get; set; }

        public string Trangthai { get; set; }

        public string Mota { get; set; }


    }
}