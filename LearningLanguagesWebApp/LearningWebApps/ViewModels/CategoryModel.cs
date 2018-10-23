using Languages.Business.Entity;

namespace LanguageStudyingWebApps.ViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Categories ToDomain()
        {
            return new Categories
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
