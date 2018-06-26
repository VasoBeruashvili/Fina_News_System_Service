using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fina_News_System_Service
{
    [DataContract]
    public class SecureRequest
    {
        [DataMember(Name = "public_key")]
        public string PublicKey { get; set; }

        [DataMember(Name = "private_key")]
        public string PrivateKey { get; set; }

        [DataMember(Name = "private_tdate")]
        public string PrivateDateTime { get; set; }
    }
}