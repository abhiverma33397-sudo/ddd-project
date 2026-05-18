using Application.Users;
using Application.Users.UserDtos;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userApplication.Create(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userApplication.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userApplication.GetById(id);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id,[FromForm] UserUpdateDto dto)
        {
            var imagePath = await _userApplication.Update(id, dto);

            return Ok(new
            {
                message = "Profile Updated Successfully",
                profileImage = imagePath
            });
        }
        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] FileUpload upload)
        {
            if (upload == null || upload.File == null || upload.File.Length == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "No file uploaded."
                });
            }

            var fileName = await _userApplication.UploadFile(upload);

            var fileUrl = $"{Request.Scheme}://{Request.Host}/Docs/{fileName}";

            return Ok(new
            {
                StatusCode = 200,
                Message = "File uploaded successfully.",
                FileUrl = fileUrl,
                Description = upload.Description,
                UserId = upload.UserId
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userApplication.Delete(id);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
