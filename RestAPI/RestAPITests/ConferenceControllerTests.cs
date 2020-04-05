using Newtonsoft.Json;
using NUnit.Framework;
using RestAPI.Controllers;
using RestAPI.Models;
using System.Collections.Generic;
using RestAPI.Common.CustomExceptions;
using System;

namespace RestAPITests
{
    public class ConferenceControllerTests
    {
        [Test]
        public void Get()
        {
            var result = new List<ConferenceWithoutIDModel>();
            var testController = new ConferencesController();
            Assert.AreEqual(result.GetType(), testController.Get().GetType());
        }


        [Test]
        public void GetByTitleWithCorrectTitle()
        {
            var result = new List<ConferenceWithoutIDModel>();
            var testController = new ConferencesController();
            Assert.AreEqual(result.GetType(), testController.GetByTitle("Techfest 2019").GetType());
        }

        [Test]
        public void GetByTitleWithWrongTitle()
        {
            var result = new NotFoudException("Conferences not found", 404);
            var testController = new ConferencesController();
            //Assert.Throws(result, testController.GetByTitle("WrongName"));
        }


        [Test]
        public void Post()
        {

        }


        [Test]
        public void PutWithCorrectData()
        {

        }

        [Test]
        public void PutWithIncorrectId()
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
