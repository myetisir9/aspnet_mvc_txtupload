using AspEntity.Concrete;
using Business.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommingText
{
    public class CommingTextManagerHelper
    {
        public static void Add(string entity, ICommingTextService commingTextService)
        {
            commingTextService.Add(JsonConvert.DeserializeObject<CommingTextEntities>(entity));
        }

        //public void Delete(CommingTextEntities entity)
        //{
        //    throw new NotImplementedException();
        //}

        public static string GetAll(ICommingTextService commingTextService)
        {
            return JsonConvert.SerializeObject(commingTextService.GetAll());
        }

        //public CommingTextEntities GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(CommingTextEntities entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
