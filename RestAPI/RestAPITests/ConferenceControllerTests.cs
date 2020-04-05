using Newtonsoft.Json;
using NUnit.Framework;
using RestAPI.Controllers;
using RestAPI.Models;
using System.Collections.Generic;
using RestAPI.Common.CustomExceptions;
using System;
using NUnit.Framework.Internal;

namespace RestAPITests
{
    public class ConferenceControllerTests
    {
        [Test]
        public void Get()
        {
            var testController = new ConferencesController();
            Assert.DoesNotThrow(delegate { testController.Get(); });
        }


        [Test]
        public void GetByTitleWithCorrectTitle()
        {
            var result = new List<ConferenceWithoutIDModel>();
            var testController = new ConferencesController();
            Assert.AreEqual(result.GetType(), testController.GetByTitle("SunshinePHP").GetType());
        }

        [Test]
        public void GetByTitleWithWrongTitle()
        {
            var testController = new ConferencesController();
            Assert.Throws<NotFoudException>(delegate { testController.GetByTitle("WrongName"); });
        }


        [Test]
        public void Post()
        {
            var testConference = new ConferenceWithoutIDModel();
            var result = new Guid().ToString("N");
            var testController = new ConferencesController();
            Assert.AreEqual(result.GetType(), testController.Post(testConference).GetType());
        }


        [Test]
        public void PutWithCorrectData()
        {
            var testConference = new ConferenceWithoutIDModel();
            var testId = "5c092621a19ac14bd086c3ae";
            var testController = new ConferencesController();
            Assert.DoesNotThrow(delegate { testController.Put(testConference, testId); });
        }

        [Test]
        public void PutWithIncorrectId()
        {
            var testConference = new ConferenceWithoutIDModel();
            var testId = new Guid().ToString("N");
            var testController = new ConferencesController();
            Assert.Throws<NotFoudException>(delegate { testController.Put(testConference, testId); });
        }


      /*  [Test]
        public void DeleteWithCorrectId()
        {
            var testConference = new ConferenceWithoutIDModel();
            var testId = "5c542880c32bcb68a567680f";
            var testController = new ConferencesController();
            Assert.DoesNotThrow(delegate { testController.Delete(testId); });
        } */

        [Test]
        public void DeleteWithIncorrectId()
        {
            var testConference = new ConferenceWithoutIDModel();
            var testId = new Guid().ToString("N");
            var testController = new ConferencesController();
            Assert.Throws<NotFoudException>(delegate { testController.Delete(testId); });
        }
    }
}
