using Codere.Models;

namespace Codere.Services
{
    public interface ITvMazeService
    {
        Task FetchAndStoreShowsAsync();

        Task<List<Show>> ObtenerShow();
    }
}
