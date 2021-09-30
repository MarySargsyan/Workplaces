using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Workplaces.Controllers;
using Workplaces.Models;
using Workplaces.Service;

namespace App.Tests
{
    [TestClass]
    public class TestWorkplacesController
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new Mock<AppDbContext>().Object;
            var workPlaces = new Mock<IWorkPlacesService>().Object;
            WorkplacesController controller = new WorkplacesController(context, workPlaces);
            var result = controller.Details(0);
        }
    }
}
