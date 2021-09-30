using Moq;
using System;
using Workplaces.Controllers;
using Workplaces.Models;
using Workplaces.Service;
using Xunit;

namespace ApplicationTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var context = new Mock<AppDbContext>().Object;
            var workPlaces = new Mock<IWorkPlacesService>().Object;

           WorkplacesController controller = new WorkplacesController(context, workPlaces);
            var result = controller.Details(0);
        }
    }
}
