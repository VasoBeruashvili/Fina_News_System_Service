using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fina_News_System_Service
{
    [DataContract]
    public class NewsFilterModel
    {
        [DataMember(Name = "k")]
        public string Key { get; set; }

        [DataMember(Name = "c")]
        public string Code { get; set; }

        [DataMember(Name = "li")]
        public int LastID { get; set; }

        [DataMember(Name = "mti")]
        public List<int> ModuleTypeIDs { get; set; }
    }    
}