using Languages.Business.Entity;

namespace LanguageStudyingWebApps.ViewModels
{
    public class WordModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Type { get; set; }
        public string Pronunciation { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Translation { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Words ToDomain()
        {
            return new Words
            {
                Id = Id,
                Word = Word,
                Type = Type,
                Pronunciation = Pronunciation,
                Meaning = Meaning,
                Example = Example,
                Translation = Translation,
                Note = Note,
                Image = Image,
                CategoryId = CategoryId,
                CategoryName = CategoryName
            };
        }

        public WordModel() { }
        public WordModel(Words entity)
        {
            Id = entity.Id;
            Word = entity.Word;
            Type = entity.Type;
            Pronunciation = entity.Pronunciation;
            Meaning = entity.Meaning;
            Example = entity.Example;
            Translation = entity.Translation;
            Note = entity.Note;
            Image = entity.Image;
            CategoryId = entity.CategoryId;
            CategoryName = entity.CategoryName;
        }
    }
}
