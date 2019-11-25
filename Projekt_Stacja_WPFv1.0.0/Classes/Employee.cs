using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStacjaWPF.Classes
{
    class Employee : User
    {
        public Employee(int id, string u, string p, string m, string n, string s, int a, int r, String city, String street, String code, String pesel, String nip, String regon, String points) : base(id, u, p, m, n, s, a, r, city, street, code, pesel, nip, regon, points)
        {
            
        }
    }
}
