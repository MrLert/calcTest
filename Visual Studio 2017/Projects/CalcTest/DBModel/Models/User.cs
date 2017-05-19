using System;
using System.Data;

namespace WebCalcNew.Managers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}