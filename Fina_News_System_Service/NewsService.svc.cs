using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Fina_News_System_Service
{
   
    public class NewsService : INewsService
    {

        public async Task<NewsResponse> GetNews(SecureRequest Secure, NewsFilterModel Request)
        {
            if (!CryptoSecurityInternal.IsRequestValid(Secure) || Request == null)
                return null;

            return await Task.Factory.StartNew(() => new BusinessLogic().GetNews(Request));
        }
    }
}
