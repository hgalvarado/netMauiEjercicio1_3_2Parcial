using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace netMauiEjercicio1_3.Models
{
    public class ClassPerson
    {
        [PrimaryKey, AutoIncrement] 
        public int idClass { get; set; }

        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(100)]
        public string lastName { get; set; }
        [MaxLength(5)]
        public int age { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(200)]
        public string address { get; set; }

    }
}
