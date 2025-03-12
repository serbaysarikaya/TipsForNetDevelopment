namespace Record.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }=null!;
        public string Password { get; set; } = null!;
        public string RemenberMe { get; set; } = null!;
    }
    public record Login(
        string Email,
        string Password,
        bool RemenberMe = true);
}
