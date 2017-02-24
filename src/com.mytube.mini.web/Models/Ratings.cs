using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.mytube.mini.web.Models
{
    public class Ratings
    {
        public int Id { get; set; }

        //[ForeignKey("Users")]
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public Videos Video { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime AddedDate { get; set; }

        //public virtual Users User { get; set; }

    }
}
