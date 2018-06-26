using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fina_News_System_Service
{
    [DataContract]
    public class NewsResponse
    {
        [DataMember(Name = "li")]
        public int LastID { get; set; }

        [DataMember(Name = "em")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "nm")]
        public List<NewsModel> NewsItems { get; set; }
    }
}