using System.Collections.Generic;
using RestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        [HttpGet]
        public List<ConferenceWithoutIDModel> Get()
        {
            return WorkWithData.AllConferences();
        }

        [Route("getbytitle")]
        [HttpGet]
        public List<ConferenceWithoutIDModel> GetByTitle(string title)
        {
            return WorkWithData.ConferenceByTitle(title);
        }

        [HttpPost]
        public string Post([FromBody] ConferenceWithoutIDModel conference)
        {
            return WorkWithData.PutConference(conference);
        }

        [HttpPut]
        public void Put([FromBody] ConferenceWithoutIDModel conference, string id)
        {
            WorkWithData.UpdateConference(conference, id);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            WorkWithData.DeleteConference(id);
        }
    }
}
