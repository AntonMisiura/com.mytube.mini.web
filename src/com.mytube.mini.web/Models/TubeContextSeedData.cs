using System;
using System.Linq;
using System.Threading.Tasks;

namespace com.mytube.mini.web.Models
{
    public class TubeContextSeedData
    {
        private TubeContext _context;

        public TubeContextSeedData(TubeContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if(!_context.Users.Any() && !_context.Videos.Any() && !_context.Ratings.Any())
            {
                var user = new Users();
                var video = new Videos();
                var ratings = new Ratings();

                var video1 = new Videos()
                {
                    AddedDate = DateTime.UtcNow,
                    VideoName = "Video 1"
                };
                var video2 = new Videos()
                {
                    AddedDate = DateTime.UtcNow,
                    VideoName = "Video 2"
                };
                var video3 = new Videos()
                {
                    AddedDate = DateTime.UtcNow,
                    VideoName = "Video 3"
                };
                //TODO add data from forms
                user.FullName = "";
                user.Login = "";
                user.Password = "";
                user.RegistrationDate = DateTime.UtcNow;

                video.AddedDate = DateTime.UtcNow;
                video.Path = "";
                video.ScreenPath = "";
                video.VideoName = "";

                ratings.AddedDate = DateTime.UtcNow;
                ratings.Comment = "";
                ratings.Rating = 1;
                //ratings.UserId = ;
                //ratings.VideoId = ;

                _context.Users.Add(user);
                _context.Videos.Add(video);
                _context.Videos.Add(video1);
                _context.Videos.Add(video2);
                _context.Videos.Add(video3);
                _context.Ratings.Add(ratings);
                await _context.SaveChangesAsync();
            }
        }
    }
}
