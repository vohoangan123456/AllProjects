using Languages.Business.Entity;

namespace Languages.Data.Entity
{
    public class WordsDTO
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
                Image = Image
            };
        }
    }
}
