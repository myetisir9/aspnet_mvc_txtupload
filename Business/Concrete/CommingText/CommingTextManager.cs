using AspEntity.Concrete;
using Business.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommingText
{
    public class CommingTextManager : ICommingTextService
    {
        private readonly CommingTextDal _commingTextDal;
        public CommingTextManager(CommingTextDal commingTextDal)
        {
            _commingTextDal = commingTextDal;
        }
        public void Add(CommingTextEntities entity)
        {
            _commingTextDal.Add(entity);
        }

        public void Delete(CommingTextEntities entity)
        {
            _commingTextDal.Delete(entity);
        }

        public List<CommingTextEntities> GetAll()
        {
            return _commingTextDal.GetAll();
        }

        public CommingTextEntities GetById(int id)
        {
            return _commingTextDal.Get(p => p.Id == id);
        }

        public void Update(CommingTextEntities entity)
        {
            _commingTextDal.Update(entity);
        }
    }
}
