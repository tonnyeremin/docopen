using System;
using DocOpen.Core;

namespace DocOpen.Data
{
    public class Project
    {
        public int Id{get; set;}
        public int SubmissionId{get; set;}
        public int UserId{get; set;}
        public string Name{get; set;}
        public string Description {get; set;}
        public EProjectState State {get; set;}
        public DateTime StartDateUtc{get; set;}
        public DateTime EndDateUtc{get; set;}
    }
}