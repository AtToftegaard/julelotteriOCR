using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationImageRecognition.Models;

namespace WebApplicationImageRecognition.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadPhotoOfSingleCard(HttpPostedFileBase file) {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            byte[] fileContents;
            if (file.ContentLength > 4200000) { fileContents = downScale(file); }
            else {
                fileContents = new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
            }
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0b898d8fca9a45bc89b2fd680b076b77");
            var uri = "https://northeurope.api.cognitive.microsoft.com/vision/v2.0/recognizeText?mode=Printed";
            HttpResponseMessage response;
            IEnumerable<string> operationLocation;
            using (var content = new ByteArrayContent(fileContents)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                Recognitionresult number = null;
                if (response.Headers.TryGetValues("Operation-Location", out operationLocation)) {
                    number = await GetTextResult(operationLocation.FirstOrDefault());
                }
                ViewBag.Number = number;
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            ViewBag.ElapsedMs = elapsedMs;
            return View("Index");
        }

        private byte[] downScale(HttpPostedFileBase file) {
            using (Stream inputStream = file.InputStream) {
                Image image = Image.FromStream(inputStream);

                if (image.Width > 4000 || image.Height > 4000) {
                    image = new Bitmap(image, new Size(image.Width / 3, image.Height / 3));
                }
                ImageConverter _imageConverter = new ImageConverter();
                byte[] imageInBytesConverted = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
                return imageInBytesConverted;
            }
        }


        private async Task<Recognitionresult> GetTextResult(string operationLocationURI) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "0b898d8fca9a45bc89b2fd680b076b77");
            bool completed = false;
            string body = null;
            while (!completed) {
                HttpResponseMessage response = await client.GetAsync(operationLocationURI);
                body = await response.Content.ReadAsStringAsync();
                if (!body.Contains("Not Started") && !body.Contains("Running")) { completed = true; } else { await Task.Delay(500); }
            }
            PredictionResult predResult = JsonConvert.DeserializeObject<PredictionResult>(body);
            return predResult.recognitionResult;
        }
    }
}