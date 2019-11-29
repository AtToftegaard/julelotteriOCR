using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TimelineObjectDetection;
using WebApplicationImageRecognition.Models;

namespace WebApplicationImageRecognition.Controllers
{
    public class MultipleCardsController : Controller
    {
        // GET: MultipleCards
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhotoOfMultipleCards(HttpPostedFileBase file)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                byte[] fileContents = new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
                // Make image smaller if it's bigger than 4000pixels and rotate if necessary
                byte[] image = PrepareImage(fileContents);
                // Call CustomVision API
                var responseObject = CallCustomVisionAPI(image);
                // Translate the response from CustomVision and draw the translated text on the picture
                TranslateAndDrawTextToPicture(responseObject);
                ViewBag.Results = responseObject;
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            ViewBag.ElapsedMs = elapsedMs;
            return View("Index");
        }

        
        private byte[] PrepareImage(byte[] imageInBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageInBytes))
            {
                Image image = Image.FromStream(memoryStream);

                if (image.Width > 4000 || image.Height > 4000)
                {
                    image = new Bitmap(image, new Size(image.Width / 3, image.Height / 3));
                }

                RotateImageBasedOnExifProperty(image);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imageInBytesConverted = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
                return imageInBytesConverted;
            }
        }

        public void TranslateAndDrawTextToPicture(ResponseObject responseObject)
        {
            Image image = null;
            using (MemoryStream memoryStream = new MemoryStream(responseObject.ImageInBytes))
            {
                image = Image.FromStream(memoryStream);
            }

            Bitmap bitmap = new Bitmap(image);
            //Bitmap bitmap = (Bitmap)Image.from.FromFile(fileName);
            Bitmap newImage = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphicImage = graphicImage = Graphics.FromImage(bitmap);

            foreach (var prediction in responseObject.Predictions)
            {
                if (prediction.Probability > (decimal)0.3)
                {
                    PointF positionOfBox = PointF.Empty;
                    SizeF sizeOfBox = SizeF.Empty;
                    SizeF halfHeightOfBox = SizeF.Empty;


                    positionOfBox = new PointF((float)prediction.BoundingBox.Left * bitmap.Width, (float)(prediction.BoundingBox.Top * bitmap.Height));
                    sizeOfBox = new SizeF((float)prediction.BoundingBox.Width * bitmap.Width, (float)(prediction.BoundingBox.Height * bitmap.Height));

                    halfHeightOfBox = new SizeF(sizeOfBox.Width, sizeOfBox.Height / 2);

                    string text1 = new TimelineTranslator().TranslateToDanish(prediction.TagName);
                    //using (Font font1 = new Font("Arial", 50, FontStyle.Bold, GraphicsUnit.Point))
                    using (Font font1 = new Font("Arial", (float)(sizeOfBox.Width * 0.07), FontStyle.Bold, GraphicsUnit.Point))
                    {
                        RectangleF rectF1 = new RectangleF(positionOfBox, halfHeightOfBox);
                        graphicImage.FillRectangle(Brushes.Green, rectF1);
                        graphicImage.DrawString(text1, font1, Brushes.White, rectF1);
                        graphicImage.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
                    }
                }
            }

            

            //bitmap.Save(@"D:\Downloads\CustomVisionResults\" + responseObject.Id + ".jpg", ImageFormat.Jpeg);
            
            graphicImage.Flush();
            

            ImageConverter _imageConverter = new ImageConverter();
            byte[] imageInBytes = (byte[])_imageConverter.ConvertTo(bitmap, typeof(byte[]));

            responseObject.ImageInBytes = imageInBytes;

            graphicImage.Dispose();
            bitmap.Dispose();
        }

        public ResponseObject CallCustomVisionAPI(byte[] image)
        {
            ResponseObject responseObject = null;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Prediction-key", "8a00cc1da2d04cd7a8c880469ba94a34");
            var uri = "https://northeurope.api.cognitive.microsoft.com/customvision/v2.0/Prediction/0a7027d0-9bf5-4ed6-b89d-a67bbe3a8609/image?";

            HttpResponseMessage response;
            using (var content = new ByteArrayContent(image))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                response = client.PostAsync(uri, content).Result;

                //string responseBody = "{\"id\":\"2d85be9d-e066-4174-9495-9738ddefbea0\",\"project\":\"0a7027d0-9bf5-4ed6-b89d-a67bbe3a8609\",\"iteration\":\"1b2b9032-d5ec-47b8-ba23-5dd10a272d4e\",\"created\":\"2019-02-03T19:16:34.4551271Z\",\"predictions\":[{\"probability\":0.9624363,\"tagId\":\"cac50759-0833-488a-b498-e455f86cd397\",\"tagName\":\"The Four Seasons\",\"boundingBox\":{\"left\":0.5876153,\"top\":0.184063375,\"width\":0.318669319,\"height\":0.6627852}},{\"probability\":0.0181686655,\"tagId\":\"2c4c154f-048a-4193-80c6-fd5cdee9f7bf\",\"tagName\":\"The Legend of Robin Hood\",\"boundingBox\":{\"left\":0.204322726,\"top\":0.3464232,\"width\":0.188371062,\"height\":0.342969716}},{\"probability\":0.937123,\"tagId\":\"2c4c154f-048a-4193-80c6-fd5cdee9f7bf\",\"tagName\":\"The Legend of Robin Hood\",\"boundingBox\":{\"left\":0.124298573,\"top\":0.1895844,\"width\":0.3235479,\"height\":0.6487212}}]}";
                string responseBody = response.Content.ReadAsStringAsync().Result;
                responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseBody);
                responseObject.ImageInBytes = image;
                return responseObject;
            }
        }

        private static int exifOrientationID = 0x112; //274
        public void RotateImageBasedOnExifProperty(Image img)
        {
            if (!img.PropertyIdList.Contains(exifOrientationID))
                return;

            var prop = img.GetPropertyItem(exifOrientationID);
            int val = BitConverter.ToUInt16(prop.Value, 0);
            var rot = RotateFlipType.RotateNoneFlipNone;

            switch (val)
            {
                case int n when (n == 2 || n == 4 || n == 5 || n == 7):
                    rot |= RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                case 4:
                    rot = RotateFlipType.Rotate180FlipNone;
                    break;
                case 5:
                case 6:
                    rot = RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                case 8:
                    rot = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    break;
            }

            if (rot != RotateFlipType.RotateNoneFlipNone)
                img.RotateFlip(rot);
        }
    }
}