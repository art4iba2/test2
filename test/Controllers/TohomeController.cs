using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
namespace test.Controllers
{
    public class TohomeController : Controller
    {
        // GET: Tohome
        public ActionResult Index()
        {
            //создаем модель
            Student[] model = new Student[1];
            model[0] = new Student { surname = "ivanov" };

            //делим юрл
            string url = Request.Url.AbsoluteUri;
            string[] urlpart = url.Split('/');
            //задаем строго типизированный тип
            List<string> urllist = urlpart.ToList();
            urllist.RemoveAt(1);
            ViewBag.url = urllist;
            //ищем студента с такой фамилией
            Student ivanov = model.FirstOrDefault(x => x.surname.ToLower() == "iv2anov");
           
            //если есть, то кидаем на не найдено. если нет то возвращаем представление с деленным юрл
           if (ivanov != null)
            {
                return new HttpNotFoundResult();

            }
            else
            {
                return View();

            }
            
        }
    }
}