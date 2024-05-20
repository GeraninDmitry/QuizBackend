using Hangfire.Dashboard;

namespace ArtQuiz.Host.Filtres;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}