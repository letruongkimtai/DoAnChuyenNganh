using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
        
        public decimal? Price { get; set; }

        public int CategoryID { get; set; }//Ten cot trong bang Product
        [ForeignKey("CategoryID")]//Chi ra khoa ngoai cua bang
        public virtual Category Categories { get; set; }//Lien ket toi bang category
    }
}