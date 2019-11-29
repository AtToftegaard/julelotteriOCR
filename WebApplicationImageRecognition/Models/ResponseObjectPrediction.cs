using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimelineObjectDetection
{
    public class ResponseObjectPrediction
    {
        public decimal Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public ResponseObjectPredictionBoundingBox BoundingBox { get; set; }
    }
}
