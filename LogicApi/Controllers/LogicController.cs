using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Behaviour GetAction(string name, World world)
        {
            return new Behaviour() { Direciton = "Up", Split = true };
        }
    }
}
