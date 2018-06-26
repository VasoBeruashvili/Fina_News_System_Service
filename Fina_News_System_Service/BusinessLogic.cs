using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Fina_News_System_Service
{
    public class BusinessLogic
    {       
        public NewsResponse GetNews(NewsFilterModel newsFilterModel)
        {
            NewsResponse finalResult = new NewsResponse();

            DataMapper dataMapper = new DataMapper();

            try
            {
                using (var context = new Fina_News_System_ServiceEntities())
                {
                    finalResult.NewsItems = new List<NewsModel>();
                    
                    if (newsFilterModel.Key != null && newsFilterModel.Code != null && newsFilterModel.LastID >= 0 && newsFilterModel.ModuleTypeIDs != null)
                    {
                        var res1 = context.News.Where(n => n.IsActive 
                        && n.ID > newsFilterModel.LastID 
                        && newsFilterModel.ModuleTypeIDs.Contains(n.ModuleTypeID.Value)
                        && (n.ShowTypeID == 1 || (n.ShowTypeID == 2 && n.NewsCompanyCodes.Any(ncc => ncc.Code == newsFilterModel.Code)) || (n.ShowTypeID == 3 
                        && n.NewsCompanyCodes.Any(ncc => ncc.Code == newsFilterModel.Key))))
                                                           .Select(a => new NewsModel
                                                           {
                                                               ID = a.ID,
                                                               Title = a.Title,
                                                               BodyText = a.BodyText,
                                                               ModuleTypeName = a.ModuleTypes.Name,
                                                               TDate = a.TDate,
                                                               TypeName = a.Types.Name
                                                           }).ToList();
                        if (res1.Any())
                        {
                            finalResult.NewsItems = res1;
                            finalResult.LastID = res1.Max(a => a.ID);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                finalResult.ErrorMessage = ex.Message;
            }

            return finalResult;
        }
    }
}