using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peoples.Models
{
    public class people
    {
        private int id;
        private string name;
        private string birthday;
        private string telephone;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}