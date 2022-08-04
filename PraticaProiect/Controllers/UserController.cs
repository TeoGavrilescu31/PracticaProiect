using AutoMapper;
using PracticaProiect.Entities;
using PracticaProiect.ExternalModels;
using PracticaProiect.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using PracticaProiect.Services.UnitsOfWork;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PraticaProiect.ExternalModels;

namespace PracticaProiect.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnit;
        private readonly IMapper _mapper;

        public UserController(IUserUnitOfWork userunit,
            IMapper mapper)
        {
            _userUnit = userunit ?? throw new ArgumentNullException(nameof(userunit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet, Authorize]
        [Route("{id}", Name ="GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var userEntity = _userUnit.Users.Get(id);
            if(userEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDTO>(userEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var userEntities = _userUnit.Users.Find(u => u.Deleted == false || u.Deleted == null);
            if (userEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<UserDTO>>(userEntities));
        }

        [Route("Register", Name = "Register new account")]
        [HttpPost, Authorize]
        public IActionResult Register([FromBody] UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userUnit.Users.Add(userEntity);

            _userUnit.Complete();

            _userUnit.Users.Get(userEntity.ID);

            return CreatedAtRoute("GetUser",
                new { id = userEntity.ID },
                _mapper.Map<UserDTO>(userEntity));
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            if(user == null)
            {
                return BadRequest("Invalid client request.");
            }

            var foundUser = _userUnit.Users.FindDefault(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password) && (u.Deleted == null || u.Deleted == false));

            if(foundUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyLOL"));
                var singingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7090/",
                    audience: "https://localhost:7090/",
                    claims: new List<Claim>(),
                    expires:DateTime.Now.AddHours(8),
                    signingCredentials: singingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
