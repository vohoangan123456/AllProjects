using Languages.Business.Entity;
using Languages.DataLayer;
using System.Collections.Generic;

namespace Languages.Business
{
    public class WordsService : IWordsService
    {
        public readonly IWordsDatalayer m_DataLayer;

        public WordsService(IWordsDatalayer datalayer)
        {
            m_DataLayer = datalayer;
        }

        public int Create(Words request)
        {
            return m_DataLayer.Create(request);
        }

        public bool Update(Words request)
        {
            return m_DataLayer.Update(request);
        }

        public bool Delete(IEnumerable<int> ids)
        {
            return m_DataLayer.Delete(ids);
        }

        public Words GetWordById(int id)
        {
            return m_DataLayer.GetWordById(id);
        }

        public IEnumerable<Words> GetActiveWords()
        {
            return m_DataLayer.GetActiveWords();
        }
    }
}
