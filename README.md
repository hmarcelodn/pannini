# Panini m:IDeal HTTP Interface Specs #


> .NET Web Api Proof Of Concept and Full Panini Device Configuration

---

## Connectivity ##

Panini m:IDeal device is configured under *Infrastructure Topology (Wi-Fi-Ethernet)*. Under this scenario the DHCP server of the network provides usually a fixed IP address (A DNS entry will be necesary for production environments). This is a configuration should be done by infrastructure teams.

## Panini endpoints ##

- **/scan:** Start scanning checks.

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
- **/results/micr:** Retrive MICR from the server. (Only works with real checks because the wathermark)

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

- **/results/front_image:** Retrieve Image bytes array. 

        [HttpGet]
        [Route("ImageResult")]
        public IHttpActionResult GetImageResult()
        {
            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/front_image");

            //store image as bytes/bloop

            return Ok(byteResponse);
        }
- **/results/barcode_front:** Retrieve the barcode. (Only works with real checks)

        [HttpGet]
        [Route("BarcodeResult")]
        public IHttpActionResult GetBarcodeResult()
        {
            byte[] byteResponse = new WebClient().DownloadData(_connection + "/results/barcode_front");

            return Ok(byteResponse);

        }

## Screen Cast Available ##

[http://www.google.com](http://www.google.com "Panini Demo")
