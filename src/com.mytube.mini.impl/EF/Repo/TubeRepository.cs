using System.Collections.Generic;
using System.Linq;
using com.mytube.mini.core.Contracts;
using com.mytube.mini.core.Entities;
using Microsoft.Extensions.Logging;

namespace com.mytube.mini.impl.EF.Repo
{
    public class TubeRepository : ITubeRepository
    {
        private ILogger<TubeRepository> _logger;
        private TubeContext _context;

        public TubeRepository(TubeContext context,
            ILogger<TubeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Video> GetAllVideos()
        {
            _logger.LogInformation("Getting all videos from DB");

            return _context.Videos.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            _logger.LogInformation("Getting all users from DB");

            return _context.Users.ToList();
        }

        public IEnumerable<Rating> GetAllRatings()
        {
            _logger.LogInformation("Getting all ratings from DB");

            return _context.Ratings.ToList();
        }
    }
}
