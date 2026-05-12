using Microsoft.AspNetCore.Http;

namespace Domain.Users
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
