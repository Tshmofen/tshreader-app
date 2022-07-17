using System.ComponentModel.DataAnnotations.Schema;

namespace tshreader.core.Domain.Models.Books;

public class Book : BaseEntity
{
    public string Name { get; set; }

    public string Author { get; set; }
    
    [ForeignKey(nameof(Media))]
    public string MediaId { get; set; }
}
