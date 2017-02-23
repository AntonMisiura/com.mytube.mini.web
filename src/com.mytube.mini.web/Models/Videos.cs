using System;

namespace com.mytube.mini.web.Models
{
    public class Videos
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string VideoName { get; set; }
        public string Path { get; set; }
        public string ScreenPath { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
