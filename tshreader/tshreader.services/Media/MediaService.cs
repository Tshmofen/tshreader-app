using eMedia = tshreader.core.Domain.Models.Media.Media;
using SQLite;
using tshreader.core.Repository;

namespace tshreader.services.Media;

internal class MediaService : IMediaService
{
    #region Ctor

    private readonly IRepository<eMedia> _repository;

    public MediaService(IRepository<eMedia> repository)
    {
        _repository = repository;
    }

    #endregion

    public async Task<eMedia> GetMediaAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task AddMediaAsync(eMedia media)
    {
        await _repository.AddAsync(media);
    }

    public async Task UpdateMediaAsync(eMedia media)
    {
        await _repository.UpdateAsync(media);
    }

    public async Task DeleteMediaAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

}
