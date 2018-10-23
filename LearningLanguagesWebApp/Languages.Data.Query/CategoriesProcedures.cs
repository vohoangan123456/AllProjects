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
    public class CategoriesProcedures : ConnectionBase, ICategoriesProcedures
    {
        public CategoriesProcedures(IConnectionFactory factory) : base(factory)
        {
        }

        public int Create(CategoriesDTO request)
        {
            return Execute(
                    connection => connection.Query<int>("[dbo].[CreateNewCategory]",
                    new
                    {
                        CategoryName = request.Name
                    },
                    commandType: CommandType.StoredProcedure)
                ).First();
        }

        public bool Update(CategoriesDTO request)
        {
            try
            {
                Execute(connection => connection.Execute("[dbo].[UpdateCategory]",
                    new
                    {
                        Id = request.Id,
                        Name = request.Name
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
                Execute(connection => connection.Execute("[dbo].[DeleteCategory]",
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

        public IEnumerable<CategoriesDTO> GetActiveCategories()
        {
            return Execute(connection => connection.Query<CategoriesDTO>("[dbo].[GetActiveCategories]",
                new { },
                commandType: CommandType.StoredProcedure));
        }
    }
}
