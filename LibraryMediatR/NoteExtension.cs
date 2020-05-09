using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace LibraryMediatR
{
    public class NoteExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<INote, Note>(new PerThreadLifetimeManager());
        }
    }
}
