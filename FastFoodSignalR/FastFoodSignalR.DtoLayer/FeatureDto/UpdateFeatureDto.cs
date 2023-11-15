using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeauteID { get; set; }
        public string FeauteTitle { get; set; }
        public string FeauteDescription { get; set; }
    }
}
