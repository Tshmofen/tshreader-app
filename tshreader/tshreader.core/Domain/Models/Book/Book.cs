namespace tshreader.core.Domain.Models.Book;

public class Book : BaseEntity
{
    public string Name { get; set; }

    public string Author { get; set; }
    
    public string MediaId { get; set; }
}
