using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebApplicationImageRecognition.Models;

namespace WebApplicationImageRecognition.Models
{
    public class PredictionResult
    {
        public string status { get; set; }
        public Recognitionresult recognitionResult { get; set; }

        public PredictionResult() { }

    }

    public class Recognitionresult
    {
        public Line[] lines { get; set; }
    }

    public class Line
    {
        public int[] boundingBox { get; set; }
        public string text { get; set; }
        public Word[] words { get; set; }
    }

    public class Word
    {
        public int[] boundingBox { get; set; }
        public string text { get; set; }
    }


}

public static class Extensions
{
    public static List<string> GetLotteryNumbers(this Recognitionresult recResult) {
        Regex rx = new Regex("Nr. [0-9]{4}");
        List<String> list = new List<string>();
        foreach (Line line in recResult.lines) {
            if (rx.IsMatch(line.text)) { list.Add(rx.Match(line.text).Value); }
        }
        return list;
    }
}