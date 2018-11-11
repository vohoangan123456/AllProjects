using Languages.Business.Entity;
using Languages.Data.Entity;
using Languages.Data.Query;
using System.Collections.Generic;
using System.Linq;

namespace Languages.DataLayer
{
    public class WordsDatalayer : IWordsDatalayer
    {
        private readonly IWordsProcedures m_Procedures;
        public WordsDatalayer(IWordsProcedures procedures)
        {
            m_Procedures = procedures;
        }

        public int Create(Words request)
        {
            return m_Procedures.Create(new WordsDTO
            {
                Word = request.Word,
                Type = request.Type,
                Pronunciation = request.Pronunciation,
                Meaning = request.Meaning,
                Example = request.Example,
                Translation = request.Translation,
                Note = request.Note,
                CategoryId = request.CategoryId
            });
        }

        public bool Update(Words request)
        {
            return m_Procedures.Update(new WordsDTO
            {
                Id = request.Id,
                Word = request.Word,
                Type = request.Type,
                Pronunciation = request.Pronunciation,
                Meaning = request.Meaning,
                Example = request.Example,
                Translation = request.Translation,
                Note = request.Note,
                CategoryId = request.CategoryId
            });
        }

        public bool Delete(IEnumerable<int> ids)
        {
            return m_Procedures.Delete(ids);
        }

        public Words GetWordById(int id)
        {
            return m_Procedures.GetWordById(id).ToDomain();
        }

        public IEnumerable<Words> GetActiveWords()
        {
            return m_Procedures.GetActiveWords().Select(x => x.ToDomain());
        }
    }
}
