using DataAccess.Models;

namespace Pagination.DTOs;

public class PaginationDTO<T>
    where T:class 
{
    public IList<T> Datas { get; set; } = new List<T>();

    public int TotalPageCount { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
