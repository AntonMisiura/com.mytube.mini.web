using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace com.mytube.mini.web.Models
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

        public IEnumerable<Videos> GetAllVideos()
        {
            _logger.LogInformation("Getting all videos from DB");

            return _context.Videos.ToList();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            _logger.LogInformation("Getting all users from DB");

            return _context.Users.ToList();
        }

        public IEnumerable<Ratings> GetAllRatings()
        {
            _logger.LogInformation("Getting all ratings from DB");

            return _context.Ratings.ToList();
        }
    }
}
