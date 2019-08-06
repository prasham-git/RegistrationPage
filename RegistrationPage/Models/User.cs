using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RegistrationPage.Models
{
    public class User
    {
        private int uid;
        private string uname;
        private string upassword;
        private string uemail;
        private double uphone;
        private string ugender;
        private DateTime udob;


        [DisplayName("Enter ID")]
        [Required(ErrorMessage = "Id is required")]
        [Key]
        public int Uid { get => uid; set => uid = value; }

        [DisplayName("Enter Name")]
        [Required(ErrorMessage = "Full name required")]
        [StringLength(10,ErrorMessage ="Length should be 10 characters")]
        public string Uname { get => uname; set => uname = value; }

        [DisplayName("Enter Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Upassword { get => upassword; set => upassword = value; }

        [DisplayName("Enter Email")]
        public string Uemail { get => uemail; set => uemail = value; }

        [DisplayName("Enter Phone number")]
        public double Uphone { get => uphone; set => uphone = value; }

        [DisplayName("Select your Gender")]
        public string Ugender { get => ugender; set => ugender = value; }

        [DisplayName("Enter Date of birth")]
        [DataType(DataType.Date,ErrorMessage ="date not in correct format")]
        public DateTime Udob { get => udob; set => udob = value; }
    }
}