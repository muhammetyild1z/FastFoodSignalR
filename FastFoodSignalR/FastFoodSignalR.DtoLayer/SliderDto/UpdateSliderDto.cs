using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DtoLayer.SliderDto
{
    public class UpdateSliderDto
    {
        public int SliderID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
