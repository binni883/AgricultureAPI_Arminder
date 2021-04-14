using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgricultureAPI_Arminder.Models
{
    public class Agriculture
    {
        public int ID { get; set; }
        public string CropName { get; set; }
        public string CropPrice { get; set; }
        public string CropSeed { get; set; }
    }
}
