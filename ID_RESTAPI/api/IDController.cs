using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdVerify.library;

namespace IdVerify.api
{
    public class IDController : ApiController
    {
       //validates Id number
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage msg = new HttpResponseMessage(); ;
            IdVerifyNumber verify = new IdVerifyNumber(id);
            try
            {
                verify.Validate();
                msg.Content = new StringContent(verify._response);
            }
            catch
            {
                msg = Request.CreateResponse(HttpStatusCode.BadRequest, "Error in Validating");
            }
            return msg;
        }

        //Generates a new id number
        public HttpResponseMessage Get()
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            GenerateNewId newID;
            try 
            {
                newID = new GenerateNewId();
                msg.Content = new StringContent(newID.NewID);
            }
            catch
            {
                msg = Request.CreateResponse(HttpStatusCode.BadRequest, "Error in Generating new ID");
            }
            return msg;
        }

    }
}