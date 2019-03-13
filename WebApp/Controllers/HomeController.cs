using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using StackExchange.Redis;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public static Logger logger = LogManager.GetLogger("SimpleDemo");
        public static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis.webapp.com:6379");
        public IActionResult Index()
        {
            var log = $"客户端：{HttpContext.Connection.RemoteIpAddress} 访问了Index页面";
            logger.Info(log);
            //读取数据
            var db = redis.GetDatabase();
            var num = db.StringIncrement("count");
            ViewData["num"] = num;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
