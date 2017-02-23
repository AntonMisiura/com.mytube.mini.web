using System;

namespace com.mytube.mini.web.Models
{
    public class Ratings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
