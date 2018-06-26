using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fina_News_System_Service
{
    public class DataMapper
    {
        public NewsModel MapDataNewsModel(News entity)
        {
            return new NewsModel
            {
                ID = entity.ID,
                Title = entity.Title,
                TDate = entity.TDate,
                ModuleTypeName = entity.ModuleTypes.Name,
                TypeName = entity.Types.Name,
                BodyText = entity.BodyText                
            };
        }
    }
}