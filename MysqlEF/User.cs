using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MysqlEF
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(300)]
        [Column("Name")]
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
