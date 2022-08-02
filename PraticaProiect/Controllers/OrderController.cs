using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaProiect.Entities;
using PracticaProiect.ExternalModels;
using PracticaProiect.Services.UnitsOfWork;

namespace PraticaProiect.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderUnitOfWork _orderUnit;
        private readonly IMapper _mapper;

        public OrderController(IOrderUnitOfWork orderunit,
            IMapper mapper)
        {
            _orderUnit = orderunit ?? throw new ArgumentNullException(nameof(orderunit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(Guid id)
        {
            var orderEntity = _orderUnit.Orders.Get(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDTO>(orderEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orderEntities = _orderUnit.Orders.Find(o => o.Deleted == false || o.Deleted == null);
            if (orderEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<OrderDTO>>(orderEntities));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetOrderDetails")]
        public IActionResult GetOrderDetails(Guid id)
        {
            var orderEntity = _orderUnit.Orders.GetOrderDetails(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDTO>(orderEntity));
        }
        [HttpPost]
        [Route("add", Name = "AddOrder")]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _orderUnit.Orders.Add(orderEntity);
            _orderUnit.Complete();
            _orderUnit.Orders.Get(order.ID);
            return CreatedAtRoute("GetOrder", new { id = order.ID }, _mapper.Map<OrderDTO>(orderEntity));
        }

    }
}
