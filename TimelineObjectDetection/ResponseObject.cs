using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineObjectDetection
{
    public class ResponseObject
    {
        public string Id { get; set; }
        public List<ResponseObjectPrediction> Predictions { get; set; }
        public byte[] ImageInBytes { get; set; }
        public Image Image { get; set; }
    }
}
