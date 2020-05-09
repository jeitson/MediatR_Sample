using LibraryMediatR.Command;
using LibraryMediatR.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIMediatR.Controllers
{
    public class NoteController : ApiController
    {
        private IMediator mediator;
        public NoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("api/note")]
        public async Task<IHttpActionResult> Add(string text)
        {
            AddNoteCommand.Request request = new AddNoteCommand.Request() {
                Text = text
            };
            var response = await mediator.Send(request, default);
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/note")]
        public async Task<IHttpActionResult> Delete(string text)
        {
            DeleteNoteCommand.Request request = new DeleteNoteCommand.Request()
            {
                Text = text
            };
            var response = await mediator.Send(request, default);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/note/list")]
        public async Task<IHttpActionResult> List()
        {
            ListNotesQuery.Request request = new ListNotesQuery.Request()
            {
            };
            var response = await mediator.Send(request, default);
            return Ok(response);
        }
    }
}
