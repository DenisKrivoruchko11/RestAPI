using Newtonsoft.Json;
using NUnit.Framework;
using RestAPI.Controllers;
using RestAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace RestAPITests
{
    public class ConferenceControllerTests
    {
        [Test]
        public void Get()
        {
            var result = 13;
            var testController = new ConferencesController();
            Assert.AreEqual(result, testController.Get().Count);
        }


        [Test]
        public void GetByTitleWithCorrectTitle()
        {
            var result = 13;
            var testController = new ConferencesController();
            Assert.AreEqual(result, testController.Get().Count);
        }

        [Test]
        public void GetByTitleWithWrongTitle()
        {

        }

        [Test]
        public void GetByTitleWithIncorrectData()
        {

        }


        [Test]
        public void PostWithCorrectData()
        {

        }

        [Test]
        public void PostWithIncorrectData()
        {

        }


        [Test]
        public void PutWithCorrectData()
        {

        }

        [Test]
        public void PutWithCorrectIdAndIncorrectBody()
        {

        }

        [Test]
        public void PutWithIncorrectIdAndCorrectBody()
        {

        }

        [Test]
        public void PutWithIncorrectData()
        {

        }


        [Test]
        public void DeleteWithCorrectId()
        {

        }

        [Test]
        public void DeleteWithIncorrectId()
        {

        }
    }
}
