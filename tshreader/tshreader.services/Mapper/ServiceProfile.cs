using AutoMapper;
using JetBrains.Annotations;
using tshreader.core.Domain.Models.Books;
using tshreader.core.Domain.Models.Media;
using tshreader.core.Domain.Models.Resources;
using tshreader.core.Domain.Models.Settings;
using tshreader.services.Models.Books;
using tshreader.services.Models.Media;
using tshreader.services.Models.Resources;
using tshreader.services.Models.Settings;

namespace tshreader.services.Mapper;

[UsedImplicitly]
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Book, BookModel>();
        CreateMap<BookModel, Book>();

        CreateMap<Media, MediaModel>();
        CreateMap<MediaModel, Media>();

        CreateMap<Setting, SettingModel>();
        CreateMap<SettingModel, Setting>();

        CreateMap<Language, LanguageModel>();
        CreateMap<LanguageModel, Language>();

        CreateMap<TextResource, TextResourceModel>();
        CreateMap<TextResourceModel, TextResource>();
    }
}
