﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Example.Infrastructure
{
    public class CustomNegotiator : DefaultContentNegotiator
    {
        public override ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            if (request.Headers.UserAgent.Any(x => x.Product != null && x.Product.Name.ToLower().Equals("chrome")))
            {
                return new ContentNegotiationResult(new JsonMediaTypeFormatter(), new MediaTypeHeaderValue("application/json"));
            }
            else
            {
                return base.Negotiate(type, request, formatters);
            }
        }
    }
}