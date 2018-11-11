using Dapper;
using Languages.Data.Common;
using Languages.Data.Common.Interfaces;
using Languages.Data.Entity;
using Languages.Data.Query.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languages.Data.Query
{
    public class WordsProcedures : ConnectionBase, IWordsProcedures
    {
        public WordsProcedures(IConnectionFactory factory) : base(factory)
        {
        }

        public int Create(WordsDTO request)
        {
            return Execute(
                    connection => connection.Query<int>("[dbo].[CreateNewWord]",
                    new
                    {
                        Word = request.Word,
                        Type = request.Type,
                        Pronunciation = request.Pronunciation,
                        Meaning = request.Meaning,
                        Example = request.Example,
                        Translation = request.Translation,
                        Note = request.Note,
                        CategoryId = request.CategoryId
                    },
                    commandType: CommandType.StoredProcedure)
                ).First();
        }

        public bool Update(WordsDTO request)
        {
            try
            {
                Execute(connection => connection.Execute("[dbo].[UpdateWord]",
                    new
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
                    },
                    commandType: CommandType.StoredProcedure));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(IEnumerable<int> ids)
        {
            DataTable idsTable = ids.ConvertToDataTable();
            try
            {
                Execute(connection => connection.Execute("[dbo].[DeleteWords]",
                    new
                    {
                        Ids = idsTable
                    },
                    commandType: CommandType.StoredProcedure));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WordsDTO GetWordById(int id)
        {
            return Execute(connection => connection.Query<WordsDTO>("[dbo].[GetWordById]",
                new {
                    Id = id
                },
                commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }

        public IEnumerable<WordsDTO> GetActiveWords()
        {
            return Execute(connection => connection.Query<WordsDTO>("[dbo].[GetActiveWords]",
                new { },
                commandType: CommandType.StoredProcedure));
        }
    }
}
