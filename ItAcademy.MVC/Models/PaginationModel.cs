﻿namespace ItAcademy.MVC.Models;

public class PaginationModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}