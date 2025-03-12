namespace DataAccess.Models;

public sealed class ErrorLog
{
    public int Id { get; set; }
    public string Trace { get; set; }
    public DateTime CreateDate { get; set; }
    public string MethotName { get; set; }
}
