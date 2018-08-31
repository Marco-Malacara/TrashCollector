using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector_Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public int Zipcode { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}