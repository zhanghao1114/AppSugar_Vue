using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppSugar_Vue.Model.Base
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
    }
}
