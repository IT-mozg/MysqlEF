using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MysqlEF
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
