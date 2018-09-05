using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector_Project.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }
        public DateTime? WeekOne { get; set; }
        public DateTime? WeekTwo { get; set; }
        public DateTime? WeekThree { get; set; }
        public DateTime? WeekFour { get; set; }
        public DateTime? SpecialPickUp { get; set; }
        public DateTime? StartPickUp { get; set; }
        public DateTime? EndPickUp { get; set; }
    }
}