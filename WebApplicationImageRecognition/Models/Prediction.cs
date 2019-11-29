using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationImageRecognition.Models
{
    public class Prediction
    {
        public decimal Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }

        public string GetProbability()
        {
            return decimal.Round(Probability, 2, MidpointRounding.AwayFromZero).ToString();
        }
    }
}