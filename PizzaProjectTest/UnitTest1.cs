using Microsoft.AspNetCore.Mvc;
using PizzaOrderProject.Controllers;
using PizzaOrderProject.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PizzaProjectTest
{
    public class UnitTest1

    {
        //private readonly UserController test;

        [Fact]
        public void Get_Method()
        {
            var user = new UserController().Get();
            //Console.WriteLine(user);
            // Assert.IsType<OkObjectResult>(user);
            var items = Assert.IsType<List<UserInfo>>(user);
            Assert.Equal(4, items.Count);


        }


        [Fact]
        public void Get_Method_byUsername()
        {
            //To check if current UserNameexist in the list
            //staus should be off 200code
            //checking it by correct id and false id
            var name = "Jain_Ishi";

            IActionResult user = new UserController().Get(name);
            UserInfo p = (user as OkObjectResult).Value as UserInfo;
            Assert.Equal(name, p.UserName);
            Assert.IsType<OkObjectResult>(user as OkObjectResult);
            var o = "hshhs";
            IActionResult user2 = new UserController().Get(o);

            Assert.IsType<NotFoundResult>(user2);
            //var u = "";
            //IActionResult user3 = new UserController().Get(u);
            //Assert.NotNull(user3);
        }


        [Fact]
        public void Post_Method()
        {
            /*Id
            Username #
            Name
            Age*/

            var add1 = new UserInfo()
            {
                Id = 5,
                UserName = "Sharma_bb",
                Name = "Priyanka Motiani",
                Age = 56
            };
            IActionResult user1 = new UserController().post(add1);
            Assert.IsType<BadRequestObjectResult>(user1);

            /*Id #
            Username 
            Name
            Age*/

            var add2 = new UserInfo()
            {
                Id = 52,
                UserName = "ma_bb",
                Name = "Priyanka Motiani",
                Age = 46
            };

            IActionResult user2 = new UserController().post(add2);
            Assert.IsType<BadRequestObjectResult>(user2);

            /*Id #
            Username 
            Name
            Age#
            */

            var add3 = new UserInfo()
            {
                Id = 1,
                UserName = "ma_",
                Name = "Priyanka Motiani",
                Age = 0
            };

            IActionResult user3 = new UserController().post(add3);
            Assert.IsType<BadRequestObjectResult>(user3);

            /*Id #
            Username #
            Name
            Age#
            */
            var add4 = new UserInfo()
            {
                Id = 11,
                UserName = "Sharma_bb",
                Name = "Priyanka Motiani",
                Age = 526
            };

            IActionResult user4 = new UserController().post(add4);
            Assert.IsType<BadRequestObjectResult>(user4);
        }


        [Fact]
        public void Put_Method()
        {

            var add1 = new UserInfo()
            {
                Id = 3,
                UserName = "ma_bb",
                Name = "Priyanka Motiani",
                Age = 56
            };


            IActionResult user = new UserController().Update(add1);

            Assert.IsNotType<BadRequestObjectResult>(user);


            var add2 = new UserInfo()
            {
                Id = 3,
                UserName = "Jain_Ishi",
                Name = "Ishita Jain",
                Age = 84
            };
            IActionResult user2 = new UserController().Update(add2);

            Assert.IsType<BadRequestObjectResult>(user2);

        }


        [Fact]
        public void Delete_Method()
        {
            var str = "";

            IActionResult user = new UserController().Delete(str);

            Assert.IsType<BadRequestObjectResult>(user);

            var getId2 = "Priya_M12";
            IActionResult user2 = new UserController().Delete(getId2);

            Assert.IsType<OkObjectResult>(user2);
        }

    }
}
