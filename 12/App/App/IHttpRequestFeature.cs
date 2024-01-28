using System;
using System.Collections.Specialized;
using System.IO;

namespace App
{
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
}
