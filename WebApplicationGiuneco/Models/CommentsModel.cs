using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGiuneco.Models
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime dateTime;
        public int IDActivity { get; set; }

        public CommentsModel(int id, string title, string description, DateTime dateTime, int idActivity)
        {
            Id = id;
            Title = title;
            Description = description;
            this.dateTime = dateTime;
            IDActivity = idActivity;
        }
    }
}
