using Languages.Business.Entity;
namespace Languages.Data.Entity
{
    public class CategoriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public Categories ToDomain()
        {
            return new Categories
            {
                Id = Id,
                Name = Name,
                IsDeleted = IsDeleted
            };
        }
    }
}
