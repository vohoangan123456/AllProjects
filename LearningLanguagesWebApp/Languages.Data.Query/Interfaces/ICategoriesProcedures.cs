using Languages.Data.Entity;
using System.Collections.Generic;

namespace Languages.Data.Query
{
    public interface ICategoriesProcedures
    {
        int Create(CategoriesDTO request);
        bool Update(CategoriesDTO request);
        bool Delete(IEnumerable<int> ids);
        IEnumerable<CategoriesDTO> GetActiveCategories();
    }
}
