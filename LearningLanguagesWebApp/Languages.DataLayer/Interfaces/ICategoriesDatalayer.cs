using Languages.Business.Entity;
using System.Collections.Generic;
namespace Languages.DataLayer
{
    public interface ICategoriesDatalayer
    {
        int Create(Categories request);
        bool Update(Categories request);
        bool Delete(IEnumerable<int> ids);
        IEnumerable<Categories> GetActiveCategories();
    }
}
