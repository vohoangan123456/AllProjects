using Languages.Data.Entity;
using System.Collections.Generic;

namespace Languages.Data.Query
{
    public interface IWordsProcedures
    {
        int Create(WordsDTO request);
        bool Update(WordsDTO request);
        bool Delete(IEnumerable<int> ids);
        WordsDTO GetWordById(int id);
        IEnumerable<WordsDTO> GetActiveWords();
    }
}
