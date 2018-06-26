using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fina_News_System_Service
{
    [DataContract]
    public class NewsModel
    {
        public int ID { get; set; }

        [DataMember(Name = "ti")]
        public string Title { get; set; }

        [DataMember(Name = "td")]
        public DateTime TDate { get; set; }

        [DataMember(Name = "mtn")]
        public string ModuleTypeName { get; set; }

        [DataMember(Name = "tn")]
        public string TypeName { get; set; }

        [DataMember(Name = "bt")]
        public string BodyText { get; set; }
    }    
}