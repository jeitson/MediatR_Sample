using LibraryMediatR;
using MediatR;
using Project.Infrastructure;
using Unity;

namespace TestMediatR
{
    public class TestBase
    {
        public TestBase()
        {
            UnityConfiguration.Container.AddNewExtension<NoteExtension>();
        }
    }
}
