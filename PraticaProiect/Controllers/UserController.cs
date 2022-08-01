using AutoMapper;
using PracticaProiect.Entities;
using PracticaProiect.ExternalModels;
using PracticaProiect.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using PracticaProiect.Services.UnitsOfWork;

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

        [HttpGet]
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

        [HttpGet]
        [Route("", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var userEntities = _userUnit.Users.Find(u => u.Deleted == false || u.Deleted == null);
            if (userEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDTO>(userEntities));
        }

        [Route("Register", Name = "Register new account")]
        [HttpPost]
        public IActionResult Register([FromBody] UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userUnit.Users.Add(userEntity);

            _userUnit.Complete();

            _userUnit.Users.Get(userEntity.ID);

            return CreatedAtRoute("Get User",
                new { id = userEntity.ID },
                _mapper.Map<UserDTO>(userEntity));
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] UserDTO user)
        {
            if(user == null)
            {
                return BadRequest("Invalid client request.");
            }

            var foundUser = _userUnit.Users.FindDefault(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password) && (u.Deleted == null || u.Deleted == false));

            if(foundUser != null)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
