using Languages.Business.Entity;
using System.Collections.Generic;
namespace Languages.DataLayer
{
    public interface IWordsDatalayer
    {
        int Create(Words request);
        bool Update(Words request);
        bool Delete(IEnumerable<int> ids);
        Words GetWordById(int id);
        IEnumerable<Words> GetActiveWords();
    }
}
