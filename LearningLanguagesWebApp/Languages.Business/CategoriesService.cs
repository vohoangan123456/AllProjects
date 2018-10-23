using Languages.Business.Entity;
using Languages.DataLayer;
using System.Collections.Generic;

namespace Languages.Business
{
    public class CategoriesService : ICategoriesService
    {
        public readonly ICategoriesDatalayer m_DataLayer;

        public CategoriesService(ICategoriesDatalayer datalayer)
        {
            m_DataLayer = datalayer;
        }

        public int Create(Categories request)
        {
            return m_DataLayer.Create(request);
        }

        public bool Update(Categories request)
        {
            return m_DataLayer.Update(request);
        }

        public bool Delete(IEnumerable<int> ids)
        {
            return m_DataLayer.Delete(ids);
        }

        public IEnumerable<Categories> GetActiveCategories()
        {
            return m_DataLayer.GetActiveCategories();
        }
    }
}
