using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_Web_Ver5.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CtmID { get; set; }

        public string UserName { get; set; }
        //[Required(ErrorMessage = "Tên đăng nhập không được để trống")]

        public string Passwords { get; set; }
        //[Required(ErrorMessage = "Mật khẩu không được để trống")]

        public string CtmName { get; set; }
       //[Required(ErrorMessage = "Họ tên không được để trống")]

        public DateTime BDate { get; set; }

        public string Addr { get; set; }
        //[Required(ErrorMessage = "Địa chỉ không được để trống")]

        public string Tell { get; set; }
        //[Required(ErrorMessage = "Số điện thoại không được để trống")]

        public string Eaddr { get; set; }
    
    }
}