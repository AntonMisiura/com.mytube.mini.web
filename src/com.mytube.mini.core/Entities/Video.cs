using System;
using com.mytube.mini.core.Contracts;

namespace com.mytube.mini.core.Entities
{
    public class Video : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ScreenPath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
