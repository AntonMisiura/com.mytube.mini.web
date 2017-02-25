using System;

namespace com.mytube.mini.core.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
