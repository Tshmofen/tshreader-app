using System.ComponentModel.DataAnnotations.Schema;

namespace tshreader.core.Domain.Models.Resources;

public class TextResource : BaseEntity
{
    public string Name { get; set; }

    public string Value { get; set; }

    [ForeignKey(nameof(Language))]
    public int LanguageId { get; set; }
}
