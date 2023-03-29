using Newtonsoft.Json;
using ReadCard.Data;
using ReadCard.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ReadCard.Controllers
{
    public class CCCDController : ApiController
    {
        // GET: api/CCCD
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CCCD/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CCCD
        [HttpPost]
        [Route("api/PostCCCD")]
        public IHttpActionResult Post([FromBody] CCCDCard cccd)
        {
            CCCDCard cc = cccd;
            string s = new JavaScriptSerializer().Serialize(cc);

            if (cc != null)
            {
                CCCDEntities1 cnn = new CCCDEntities1();
                CCCD cCCD = new CCCD();
                cCCD.DATA = s;
                cCCD.CREATED_DATE = DateTime.Now;
                cnn.CCCDs.Add(cCCD);
                cnn.SaveChanges();
                return Ok();
            }
            else { return BadRequest(); }
        }

        // PUT: api/CCCD/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/CCCD/5
        public void Delete(int id)
        {
        }
    }
}
