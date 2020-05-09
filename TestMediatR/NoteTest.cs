using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using APIMediatR.Controllers;
using LibraryMediatR;
using LibraryMediatR.Command;
using LibraryMediatR.Queries;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Infrastructure;
using Unity;

namespace TestMediatR
{
    [TestClass]
    public class NoteTest : TestBase
    {
        [TestMethod]
        public async Task AddNoteTest()
        {
            var note = UnityConfiguration.Container.Resolve<INote>();
            var sut = new AddNoteCommand.Handler(note);
            var result = await sut.Handle(new AddNoteCommand.Request() { Text = "texto de prueba" }, default);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task DeleteNoteTest()
        {
            var note = UnityConfiguration.Container.Resolve<INote>();

            var add = new AddNoteCommand.Handler(note);
            var resultAdd = await add.Handle(new AddNoteCommand.Request() { Text = "texto de prueba" }, default);
            Assert.AreEqual(true, resultAdd);

            var sut = new DeleteNoteCommand.Handler(note);
            var result = await sut.Handle(new DeleteNoteCommand.Request() { Text = "texto de prueba" }, default);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task ListNoteTest()
        {
            var note = UnityConfiguration.Container.Resolve<INote>();

            var add = new AddNoteCommand.Handler(note);
            var resultAdd = await add.Handle(new AddNoteCommand.Request() { Text = "texto de prueba" }, default);
            Assert.AreEqual(true, resultAdd);

            var sut = new ListNotesQuery.Handler(note);
            var result = await sut.Handle(new ListNotesQuery.Request() {}, default);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstOrDefault().Text, "texto de prueba");
        }
    }
}
