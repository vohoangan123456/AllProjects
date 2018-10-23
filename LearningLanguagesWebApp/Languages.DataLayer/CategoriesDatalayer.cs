using Languages.Business.Entity;
using Languages.Data.Entity;
using Languages.Data.Query;
using System.Collections.Generic;
using System.Linq;

namespace Languages.DataLayer
{
    public class CategoriesDatalayer : ICategoriesDatalayer
    {
        private readonly ICategoriesProcedures m_Procedures;
        public CategoriesDatalayer(ICategoriesProcedures procedures)
        {
            m_Procedures = procedures;
        }

        public int Create(Categories request)
        {
            return m_Procedures.Create(new CategoriesDTO
            {
                Name = request.Name
            });
        }

        public bool Update(Categories request)
        {
            return m_Procedures.Update(new CategoriesDTO
            {
                Id = request.Id,
                Name = request.Name
            });
        }

        public bool Delete(IEnumerable<int> ids)
        {
            return m_Procedures.Delete(ids);
        }

        public IEnumerable<Categories> GetActiveCategories()
        {
            return m_Procedures.GetActiveCategories().Select(x => x.ToDomain());
        }
    }
}
