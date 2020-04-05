using RestAPI.Common;
using RestAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using RestAPI.Common.CustomExceptions;

namespace RestAPI
{
    static class WorkWithData
    {
        private static List<ConferenceWithIDModel> getData(string pathToFile)
        {
            List<ConferenceWithIDModel> conferences;
            using (StreamReader fileData = new StreamReader(pathToFile))
            {
                conferences = JsonConvert.DeserializeObject<List<ConferenceWithIDModel>>(fileData.ReadToEnd());
            }
            if (conferences is null) return new List<ConferenceWithIDModel>();
            return conferences;
        }

        internal static List<ConferenceWithoutIDModel> AllConferences()
        {
            var conferences = getData(Constants.pathToFile);
            List<ConferenceWithoutIDModel> result = new List<ConferenceWithoutIDModel>();
            foreach (var conference in conferences) { result.Add(conference.ToConferenceWithoutIDModel()); }
            return result;
        }

        internal static List<ConferenceWithoutIDModel> ConferenceByTitle(string title)
        {
            var isFound = false;
            var conferences = getData(Constants.pathToFile);
            List<ConferenceWithoutIDModel> result = new List<ConferenceWithoutIDModel>();
            foreach (var conference in conferences)
            {
                if (conference.title == title)
                {
                    result.Add(conference.ToConferenceWithoutIDModel());
                    isFound = true;
                }
            }
            if (!isFound) throw new NotFoudException("Conferences are not found", 404);
            return result;
        }

        internal static void DeleteConference(string id)
        {
            var isFound = false;
            var conferences = getData(Constants.pathToFile);
            foreach (var conference in conferences)
            {
                if (conference._id == id) { conferences.Remove(conference); isFound = true; break; }
            }
            if (!isFound) throw new NotFoudException("Conferences are not found", 404);
            string result = JsonConvert.SerializeObject(conferences);
            using (StreamWriter streamWriter = new StreamWriter(Constants.pathToFile, false))
            {
                streamWriter.WriteLine(result);
            }
        }

        internal static void UpdateConference(ConferenceWithoutIDModel updatedConference, string id)
        {
            var isFound = false;
            var conferences = getData(Constants.pathToFile);
            foreach (var conference in conferences)
            {
                if (conference._id == id) { conferences.Remove(conference); isFound = true; break; }
            }
            if (!isFound) throw new NotFoudException("Conferences are not found", 404);
            conferences.Add(updatedConference.ToConferenceWithIDModel(id));
            string result = JsonConvert.SerializeObject(conferences);
            using (StreamWriter streamWriter = new StreamWriter(Constants.pathToFile, false))
            {
                streamWriter.WriteLine(result);
            }
        }

        internal static string PutConference(ConferenceWithoutIDModel conference)
        {
            var conferences = getData(Constants.pathToFile);
            var id = Guid.NewGuid().ToString("N");
            conferences.Add(conference.ToConferenceWithIDModel(id));
            var result = JsonConvert.SerializeObject(conferences);
            using (StreamWriter streamWriter = new StreamWriter(Constants.pathToFile, false))
            {
                streamWriter.WriteLine(result);
            }
            return id;
        }
    }
}
