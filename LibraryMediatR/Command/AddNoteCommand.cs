using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryMediatR.Command
{
    public static class AddNoteCommand
    {
        public class Handler : IRequestHandler<Request, bool>
        {
            private readonly INote noteModule;

            public Handler(INote note)
            {
                noteModule = note;
            }

            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                bool result = false;

                try
                {
                    result = await Task.FromResult(noteModule.Add(request.Text));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return result;
            }
        }

        public class Request: IRequest<bool> {
            public string Text { get; set; }
        }
    }
}
