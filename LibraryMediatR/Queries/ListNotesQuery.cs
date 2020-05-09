using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryMediatR.Queries
{
    public static class ListNotesQuery
    {
        public class Handler : IRequestHandler<Request, List<NoteInfo>>
        {
            private readonly INote noteModule;

            public Handler(INote note)
            {
                noteModule = note;
            }

            public async Task<List<NoteInfo>> Handle(Request request, CancellationToken cancellationToken)
            {
                List<NoteInfo> result = null;

                try
                {
                    result = await Task.Run(() => noteModule.List());
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return result;
            }
        }

        public class Request : IRequest<List<NoteInfo>>
        {
        }
    }
}
