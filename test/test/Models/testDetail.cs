using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class testDetail
    {
        [Key]
        public int HotelId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string HotelName { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string HotelCity { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string HotelDistrict { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string HotelDescription { get; set; }
    }
}
