using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Fina_News_System_Service
{
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetNews", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<NewsResponse> GetNews(SecureRequest Secure, NewsFilterModel Request);
    }
}
