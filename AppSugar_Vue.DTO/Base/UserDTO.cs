using System;
using System.Collections.Generic;
using System.Text;

namespace AppSugar_Vue.DTO.Base
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
    }
}
