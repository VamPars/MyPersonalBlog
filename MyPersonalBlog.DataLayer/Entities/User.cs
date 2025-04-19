using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password  { get; set; }
        public bool  IsActivated { get; set; }
        public Guid ActivationCode { get; set; }
        public string Email { get; set; }


    }
}
