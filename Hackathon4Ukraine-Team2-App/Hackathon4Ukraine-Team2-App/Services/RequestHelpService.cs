using Hackathon4Ukraine_Team2_App.DataAccess;
using Hackathon4Ukraine_Team2_App.Domain;

namespace Hackathon4Ukraine_Team2_App.Domain
{
    public class RequestHelpService : IRequestHelpService
    {
        private readonly AppDbContext _dbContext;

        public RequestHelpService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveRequest(RequestHelp model)
        {
            _dbContext.RequestHelps.Add(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
