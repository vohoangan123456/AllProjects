using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageStudyingWebApps.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageStudyingWebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        // GET api/words
        [HttpGet]
        public ActionResult<IEnumerable<WordModel>> Get()
        {
            return new List<WordModel>();
        }

        // GET api/words/5
        [HttpGet("{id}")]
        public ActionResult<WordModel> Get(int id)
        {
            return new WordModel();
        }

        // POST api/words
        [HttpPost]
        public void Post([FromBody] WordModel value)
        {
            var update = value;
        }

        // PUT api/words/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WordModel value)
        {
        }

        // DELETE api/words/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("getdata")]
        public ActionResult<IEnumerable<WordModel>> GetWordsByFilter()
        {
            var x = 1;
            return new List<WordModel>();
        }
    }
}