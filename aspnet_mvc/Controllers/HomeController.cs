using aspnet_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.CSharp.RuntimeBinder;
using aspnet_mvc.Helper;
using Microsoft.AspNetCore.Authorization;

namespace aspnet_mvc.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddNews(int skip=0, int take=10)
        {
            var data = new ErrorViewModel<ComingTextModel>
            {
                Entities = ComingTextHelper.GetInstance().GetAllDatabase().Skip(skip).Take(take).ToList(),
                ErrorCode = 200,
                ErrorMessage = "Success",
                Result = "Ok"
            };
            return View(data);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //   // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Index1()
        {
            List<Class1> list = Class1.GetAll();
            return View(list);
        }

        [HttpPost]
        public IActionResult AddNews(IFormFile file)
        {

            if (file != null)
            {
                try
                {
                    //Set Key Name
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    //Get url To Save
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", ImageName);

                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    //List<ComingTextModel> comingtextlist = ComingTextModel.GetAll(SavePath);

                    ErrorViewModel<ComingTextModel> model = new Models.ErrorViewModel<ComingTextModel>
                    {
                        Entities = ComingTextHelper.GetInstance().GetAll(SavePath),
                        ErrorCode = ComingTextHelper.GetInstance().errorCode,
                        ErrorMessage = ComingTextHelper.GetInstance().ErrorMessage,
                    };

                    TempData["ErrorException"] = ComingTextModel.error;

                    return View("AddNews", model);
                }
                catch (FormatException e)
                {
                    return View("AddNews", "Your txt has some items that are not suitable for the format. Please try again with the following format: " +
                    "signed int, string, string, int, int, string, string, int, bool");
                }
                catch (RuntimeBinderException)
                {
                    return View("AddNews", "Your txt has some items that are not suitable for the format. Please try again with the following format: " +
                    "signed int, string, string, int, int, string, string, int, bool");

                }

            }
            else
            {
                return View("AddNews", "Couldn't upload the file. Please try again.");
            }

        }
        [HttpPost]
        public bool AddNewDatabase()
        {
          return  ComingTextHelper.GetInstance().AddNewDatabase();
        }
        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult GetDatabase(int take = 10,int skip=0)
        {
            var data = new ErrorViewModel<ComingTextModel>
            {
                Entities = ComingTextHelper.GetInstance().GetAllDatabase().Skip(skip).Take(take).ToList(),
                ErrorCode = (ComingTextHelper.GetInstance().list.Count / 20),
                ErrorMessage = "Success",
                Result = "200"
            };
            return PartialView("~/Views/partical/particalComming.cshtml",data);
        }

    }


    public class data
    {
        public string file { get; set; }
    }
}