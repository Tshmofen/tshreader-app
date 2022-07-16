using SQLiteNetExtensions.Attributes;

namespace tshreader.core.Domain.Models.Resource;

public class Resource : BaseEntity
{
    public string? Name { get; set; }

    public string? Value { get; set; }

    [ForeignKey(typeof(Language))]
    public int LanguageId { get; set; }
}
