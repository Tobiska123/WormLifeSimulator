using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WormLifeSimulator.WormLogic;

namespace LogicApi.Controllers
{
    public class LogicController : Controller
    {

        // GET: LogicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogicController/Create
        [HttpPost("{name}/getAction")]
        public Behaviour GetAction(string name, [FromBody]World world)
        {
            Console.WriteLine(world);

            Worm worm = world.Worms.Where(t => t.name == name).First();

            if (world.Foods.Count() <= 0)
            {
                return new Behaviour() {
                    Direction = "Nothing",
                    Split = false
                };
            }
            Food closestFood = Utils.ClosestFood(worm, world.Foods);
            Worm closestWorm = Utils.ClosestWorm(closestFood, world.Worms);
            if (worm == closestWorm)
            {
                if(worm.Life >= 17)
                {
                    return new Behaviour() {
                        Direction = Utils.ChooseDirection(closestFood, worm),
                        Split=true
                    };
                }
                return new Behaviour()
                {
                    Direction = Utils.ChooseDirection(worm, closestFood),
                    Split = false
                };
            }
            else
            {
                if (worm.Life >= 13)
                {
                    return new Behaviour()
                    {
                        Direction = Utils.ChooseDirection(worm, new Field() { X = 0, Y = 0 }),
                        Split = true
                    };
                }
                else
                {
                    return new Behaviour()
                    {
                        Direction = "Nothing",
                        Split = false
                    };
                }
            }
        }
    }
}
