using System.Collections.Generic;
using com.mytube.mini.core.Entities;

namespace com.mytube.mini.core.Contracts
{
    public interface ITubeRepository
    {
        IEnumerable<Rating> GetAllRatings();
        IEnumerable<User> GetAllUsers();
        IEnumerable<Video> GetAllVideos();
    }
}