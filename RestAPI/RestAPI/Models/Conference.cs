using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public class ConferenceWithoutIDModel
    {
        public string title { get; set; }
        public List<string> projects { get; set; }
        public Location location { get; set; }
        public List<string> tags { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateFinish { get; set; }
        public Dictionary<string, Participant> participants { get; set; }
        public string ytLink { get; set; }
        public int? attendance { get; set; }
        public string link { get; set; }
        public List<string> comments { get; set; }
        public string status { get; set; }

        public ConferenceWithoutIDModel() { }

        public ConferenceWithoutIDModel(
            string title,
            List<string> projects,
            Location location,
            List<string> tags,
            DateTime dateStart,
            DateTime dateFinish,
            Dictionary<string, Participant> participants,
            string ytLink,
            int? attendance,
            string link,
            List<string> comments,
            string status)
        {
            this.title = title;
            this.projects = projects;
            this.location = location;
            this.tags = tags;
            this.dateStart = dateStart;
            this.dateFinish = dateFinish;
            this.participants = participants;
            this.ytLink = ytLink;
            this.attendance = attendance;
            this.link = link;
            this.comments = comments;
            this.status = status;
        }

        internal ConferenceWithIDModel ToConferenceWithIDModel(string id)
        {
            return new ConferenceWithIDModel(
                id,
                title,
                projects,
                location,
                tags,
                dateStart,
                dateFinish,
                participants,
                ytLink,
                attendance,
                link,
                comments,
                status);
        }
    }


    class ConferenceWithIDModel
    {
        internal string _id { get; set; }
        internal string title { get; set; }
        internal List<string> projects { get; set; }
        internal Location location { get; set; }
        internal List<string> tags { get; set; }
        internal DateTime dateStart { get; set; }
        internal DateTime dateFinish { get; set; }
        internal Dictionary<string, Participant> participants { get; set; }
        internal string ytLink { get; set; }
        internal int? attendance { get; set; }
        internal string link { get; set; }
        internal List<string> comments { get; set; }
        internal string status { get; set; }

        internal ConferenceWithIDModel(
            string _id,
            string title,
            List<string> projects,
            Location location,
            List<string> tags,
            DateTime dateStart,
            DateTime dateFinish,
            Dictionary<string, Participant> participants,
            string ytLink,
            int? attendance,
            string link,
            List<string> comments,
            string status)
        {
            this._id = _id;
            this.title = title;
            this.projects = projects;
            this.location = location;
            this.tags = tags;
            this.dateStart = dateStart;
            this.dateFinish = dateFinish;
            this.participants = participants;
            this.ytLink = ytLink;
            this.attendance = attendance;
            this.link = link;
            this.comments = comments;
            this.status = status;
        }

        internal ConferenceWithoutIDModel ToConferenceWithoutIDModel()
        {
            return new ConferenceWithoutIDModel(
                title,
                projects,
                location,
                tags,
                dateStart,
                dateFinish,
                participants,
                ytLink,
                attendance,
                link,
                comments,
                status);
        }
    }


    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }

        public Location() { }

        public Location(string city, string country)
        {
            this.city = city;
            this.country = country;
        }
    }


    public class Participant
    {
        public string type { get; set; }
        public string status { get; set; }
        public bool invited { get; set; }

        public Participant() { }

        public Participant(string type, string status, bool invited)
        {
            this.type = type;
            this.status = status;
            this.invited = invited;
        }
    }
}
