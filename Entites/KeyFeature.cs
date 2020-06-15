using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KeyFeature
    {
        public int Id { get; set; }
        public int IdHaspKey { get; set; }
        public int IdFeature { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
