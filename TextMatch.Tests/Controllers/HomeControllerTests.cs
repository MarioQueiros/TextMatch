using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMatch.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void GetPositionsTest1()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "Polly";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "1, 26, 51", positions );
        }

        [TestMethod()]
        public void GetPositionsTest2()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "Polly";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "1, 26, 51", positions );
        }

        [TestMethod()]
        public void GetPositionsTest3()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "put";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "7, 32, 57", positions );
        }

        [TestMethod()]
        public void GetPositionsTest4()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "the";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "11, 36, 61", positions );
        }

        [TestMethod()]
        public void GetPositionsTest5()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "ll";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "3, 28, 53, 78, 82", positions );
        }

        [TestMethod()]
        public void GetPositionsTest6()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = string.Empty;

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "There is no output", positions );
        }

        [TestMethod()]
        public void GetPositionsTest7()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "ll";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "3, 28, 53, 78, 82", positions );
        }

        [TestMethod()]
        public void GetPositionsTest8()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "oll";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "2, 27, 52", positions );
        }

        [TestMethod()]
        public void GetPositionsTest9()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "Polx";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "There is no output", positions );
        }

        [TestMethod()]
        public void GetPositionsTest10()
        {
            HomeController controller = new HomeController();

            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
            var subText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea Polx";

            var positions = controller.GetPositions( text, subText );

            // Assert
            Assert.AreEqual( "There is no output", positions );
        }
    }
}