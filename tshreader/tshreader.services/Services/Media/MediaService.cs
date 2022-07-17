using AutoMapper;
using tshreader.core.Repository;
using tshreader.services.Models.Media;
using eMedia = tshreader.core.Domain.Models.Media.Media;

namespace tshreader.services.Services.Media;

public class MediaService : IMediaService
{
    #region Ctor

    private readonly IRepository<eMedia> _repository;
    private readonly IMapper _mapper;

    public MediaService(IRepository<eMedia> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    #endregion

    public async Task<MediaModel> GetMediaAsync(int id)
    {
        var media = await _repository.GetAsync(id);
        return _mapper.Map<eMedia, MediaModel>(media);
    }

    public async Task AddMediaAsync(MediaModel mediaModel)
    {
        var media = _mapper.Map<MediaModel, eMedia>(mediaModel);
        await _repository.AddAsync(media);
    }

    public async Task UpdateMediaAsync(MediaModel mediaModel)
    {
        var media = _mapper.Map<MediaModel, eMedia>(mediaModel);
        await _repository.UpdateAsync(media);
    }

    public async Task DeleteMediaAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

}
