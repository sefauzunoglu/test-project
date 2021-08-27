using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace il_ilce_webapi.Models
{
    public class cityDistrict
    {
        [Key]
        public int CityId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CityName { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string DistrictName { get; set; }

    }
}
