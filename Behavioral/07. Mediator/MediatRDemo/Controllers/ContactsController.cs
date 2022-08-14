using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private IMediator mediator;


        public ContactsController(IMediator m)
        {
            mediator = m;
        }


        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query)
        {
            return await mediator.Send(query);
        }


        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private ContactsContext db;

            public ContactHandler(ContactsContext contactsContext)
            {
                db = contactsContext;
            }

            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }
    }
}
