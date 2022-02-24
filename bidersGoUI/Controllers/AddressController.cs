using bidersGo.Application.Features.Queries.AddressGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAdress()
        {
            AddressGetAllQueryResponse response = await _mediator.Send(new AddressGetAllQueryRequest());

            return View(response);
        }
    }
}
