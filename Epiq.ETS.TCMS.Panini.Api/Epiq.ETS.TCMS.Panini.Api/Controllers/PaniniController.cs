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
using System.Web.Http.Cors;

namespace Epiq.ETS.TCMS.Panini.Api.Controllers
{
    [RoutePrefix("api/panini")]
    [EnableCors(origins: "http://localhost:51261", headers: "*", methods: "*")]
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


            return Ok(response.StatusCode);
        }

        [HttpGet]
        [Route("MicrResult")]
        public IHttpActionResult GetMicrResult()
        {

            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/micr");

            string micrText = string.Empty;

            using(var stream = new StreamReader(new MemoryStream(byteResponse)))
            {
                micrText = stream.ReadToEnd();
            }
            

            return Ok(micrText);
        }

        [HttpGet]
        [Route("ImageResult")]
        public IHttpActionResult GetImageResult()
        {
            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/front_image");

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
