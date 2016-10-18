using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace Epiq.ETS.TCMS.Panini.Api.Controllers
{
    [RoutePrefix("api/panini")]
    public class PaniniController : ApiController
    {
        private readonly string _connection;

        public PaniniController()
        {
            _connection = "http://192.168.0.17";
        }


        [HttpPost]
        [Route("Scan")]
        public IHttpActionResult Scan()
        {

            var request = (HttpWebRequest)WebRequest.Create(_connection + "/scan");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;

           
            var response = (HttpWebResponse)request.GetResponse();


            return Ok();
        }

        [HttpGet]
        [Route("MicrResult")]
        public IHttpActionResult GetMicrResult()
        {

            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/micr");

            using(var stream = new StreamReader(new MemoryStream(byteResponse)))
            {
                var line = stream.ReadToEnd();
                // -> save the file into an object
            }
            

            return Ok(byteResponse);
        }

        [HttpGet]
        [Route("ImageResult")]
        public IHttpActionResult GetImageResult()
        {
            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/front_image");

            //store image as bytes/bloop

            return Ok(byteResponse);
        }

        [HttpGet]
        [Route("BarcodeResult")]
        public IHttpActionResult GetBarcodeResult()
        {
            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/barcode_front");

            return Ok(byteResponse);

        }
    }
}
