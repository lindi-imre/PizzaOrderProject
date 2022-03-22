using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PizzaOrderProject.Models;

namespace PizzaOrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Configuration  configuration;

        private static List<UserInfo> userList = new List<UserInfo>
        {
            new UserInfo { Id = 1, UserName= "Priya_M12",Name = "Priyanka Motiani", Age = 34 },
            new UserInfo { Id = 2, UserName= "Jain_Ishi",Name = "Ishita Jain", Age = 24 },
            new UserInfo { Id = 3, UserName= "Sharma_bb",Name = "Booby Sharma", Age = 44 },
            new UserInfo { Id = 4,UserName= "bb_sha12", Name = "Booby Sharma", Age = 18 }
        };
        
        public int userListLength = userList.Count;
       
        private bool Valueok(string s)
        {
            List<string> userList = new List<string>();
            for (int i= 0;i<userListLength;i++)
            {
               userList.Add(UserController.userList[i].UserName);
               
            }
            if (SearchArray(userList, s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
       private bool SearchArray(List<string> array, string value)
        {

            /*int numIndex = array.BinarySearch(value);
             if (numIndex > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }*/
            array.Sort();
            int h;
            int l = 0;
            int n= array.Count;
            h = n-1;
            bool found = false;
            int compCount = 0;
            while (found!= true && l <= h)
            {
                int m = l + (h - l) / 2;

                  
                if (string.Compare(array[m], value, true) == 0)
                {
                    found = true;
                    compCount++;
                    return true;
                }
                else if(string.Compare(array[m], value, true) > 0)
                {
                    h = m-1;
                    compCount++;
                }
                else
                {
                    l = m+1;
                    compCount++;
                }
                
            }

            return false;


        }

        [HttpGet]
        public List<UserInfo> Get()
        {
            
            return userList;
        }


        [HttpGet("{username}")]
        public  IActionResult Get(string user)
        {
            var ap = userList.Find(h => h.UserName == user);
            if (ap == null)
                return NotFound();

            return Ok(ap);
        }


        [HttpPost]
         public IActionResult post(UserInfo ap)
        {

            if ((ap.Id != 0 && ap.Id == userListLength + 1) && (0 < ap.Age & ap.Age < 80)&& Valueok(ap.UserName) != true)
            {
                    userList.Add(ap);
                    return Ok(userList);
                } 
            else
            {
                return BadRequest("Not");
            }
           
        }


        [HttpPut]
        public IActionResult Update(UserInfo req)
        {
            var hero = userList.Find(h => h.Id == req.Id);
            if (hero == null)
                return BadRequest("Id not found");
            if (0 < req.Age & req.Age < 80 & Valueok(req.UserName) != true)
            {
                hero.Name = req.Name;

                hero.Age = req.Age;

                hero.UserName = req.UserName;

                return Ok(userList);
            }
            else
            {
                return BadRequest(" not valid");
            }

        }


        [HttpDelete("{usernme}")]
        public IActionResult Delete(string username)
        {
            var hero = userList.Find(h => h.UserName == username);
            if (hero == null)
                return BadRequest("UserName not found");
            userList.Remove(hero);
            return Ok(userList);
        }
    }
}
