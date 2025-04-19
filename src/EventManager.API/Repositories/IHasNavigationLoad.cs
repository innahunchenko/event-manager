using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Repositories
{
    public interface IHasNavigationLoad
    {
        Task LoadNavigationsAsync(DbContext context);
    }
}
