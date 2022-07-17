using tshreader.services.Models.Media;
namespace tshreader.services.Services.Media;

public interface IMediaService
{
    Task<MediaModel> GetMediaAsync(int id);
    Task AddMediaAsync(MediaModel mediaModel);
    Task UpdateMediaAsync(MediaModel mediaModel);
    Task DeleteMediaAsync(int id);
}
