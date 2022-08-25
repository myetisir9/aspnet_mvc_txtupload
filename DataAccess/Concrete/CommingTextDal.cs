using AspEntity.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
    public class CommingTextDal:Repository<CommingTextEntities, ContextAsp> ,ICommingText
    {
    }
}
