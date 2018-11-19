using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    [Table("tracking_users")]
    public class Users
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("hash_pass")]
        public string Password { get; set; }
    }
}
