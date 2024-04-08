using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels.Models
{
    public class Stage : BaseEntity
    {
        public long StageId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
