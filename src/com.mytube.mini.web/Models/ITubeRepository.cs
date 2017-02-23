using System.Collections.Generic;

namespace com.mytube.mini.web.Models
{
    public interface ITubeRepository
    {
        IEnumerable<Ratings> GetAllRatings();
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Videos> GetAllVideos();
    }
}