﻿using Languages.Business.Entity;
using System.Collections.Generic;

namespace Languages.Business
{
    public interface ICategoriesService
    {
        int Create(Categories request);
        bool Update(Categories request);
        bool Delete(IEnumerable<int> ids);
        Categories GetCategoryById(int id);
        IEnumerable<Categories> GetActiveCategories();
    }
}
