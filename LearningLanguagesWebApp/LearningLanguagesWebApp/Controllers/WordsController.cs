using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Languages.Business;
using Languages.Business.Entity;
using LanguageStudyingWebApps.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Languages.Common.Constants;
using Languages.Business.Common;
using System.Drawing;

namespace LanguageStudyingWebApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsService m_Service;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IImageUploader m_ImageUploader;

        public WordsController(IWordsService service, IHostingEnvironment hostingEnvironment, IImageUploader imageUploader)
        {
            m_Service = service;
            m_ImageUploader = imageUploader;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET api/words
        [HttpGet]
        public IEnumerable<WordModel> Get()
        {
            return m_Service.GetActiveWords().Select(x=>new WordModel(x));
        }

        // GET api/words/5
        [HttpGet("{id}")]
        public ActionResult<WordModel> Get(int id)
        {
            var model = new WordModel(m_Service.GetWordById(id));
            return model;
        }

        // POST api/words
        [HttpPost]
        public void Post([FromBody] WordModel value)
        {
            int id = m_Service.Create(value.ToDomain());
            if (!string.IsNullOrEmpty(value.Image))
            {
                string imagePath = string.Concat(_hostingEnvironment.ContentRootPath, Constants.WordImagePath, id, ".png");
                Image img = m_ImageUploader.Base64ToImage(value.Image);
                img.Save(imagePath);
            }
        }

        // PUT api/words/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WordModel value)
        {
            m_Service.Update(value.ToDomain());
            if (!string.IsNullOrEmpty(value.Image))
            {
                string imagePath = string.Concat(_hostingEnvironment.ContentRootPath, Constants.WordImagePath, value.Id, ".png");
                Image img = m_ImageUploader.Base64ToImage(value.Image);
                img.Save(imagePath);
            }
        }

        // DELETE api/words/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("bulkdelete")]
        public bool BulkDelete([FromBody] IEnumerable<int> ids)
        {
            return m_Service.Delete(ids);
        }

        [HttpGet("getdata")]
        public IEnumerable<WordModel> GetCategoriesByFilter()
        {
            var model = m_Service.GetActiveWords().Select(x => new WordModel(x));
            return model;
        }
    }
}