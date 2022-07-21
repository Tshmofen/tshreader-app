﻿using Microsoft.Maui.Controls;

namespace tshreader.services.Models.Books;

public class BookModel : BaseEntityModel
{
    public string Name { get; set; }

    public string Author { get; set; }

    public ImageSource Image { get; set; }
}