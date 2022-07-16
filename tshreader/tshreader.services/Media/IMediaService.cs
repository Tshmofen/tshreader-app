using eMedia = tshreader.core.Domain.Models.Media.Media;
namespace tshreader.services.Media;

public interface IMediaService
{
    Task<eMedia> GetMediaAsync(int id);
    Task AddMediaAsync(eMedia media);
    Task UpdateMediaAsync(eMedia media);
    Task DeleteMediaAsync(int id);
}
