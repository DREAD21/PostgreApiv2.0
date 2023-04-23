using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PostgreApi.DAL.Entities;

namespace PostgreApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostgreController : Controller
    {
        PesfczomContext db;
        public PostgreController(IConfiguration config, PesfczomContext context)
        {
            db = context;
            //_config = config;
        }
        [HttpGet]
        [Route("getInfo")]
        public IQueryable Age(string info, string text)
        {
            if(info == "Заголовок")
            {
                return db.Thesises.Where(p => p.Title.Contains(text));
            }
            if (info == "Фамилия студента")
            {
                return db.Thesises.Where(p => p.StudentSurname.Contains(text));
            }
            if (info == "Фамилия преподавателя")
            {
                return db.Thesises.Where(p => p.TutorSurname.Contains(text));
            }
            if (info == "Номер группы")
            {
                return db.Thesises.Where(p => p.StudentGroup.Contains(text));
            }
            if (info == "Номер кафедры")
            {
                return db.Thesises.Where(p => p.CathedraNumber.Contains(text));
            }
            return null;
        }
        [HttpGet]
        [Route("getAll")]
        public IQueryable GetQueryable()
        {
            return db.Thesises;
        }
        [HttpPost]
        public void getUser(Thesise thesise)
        {
            thesise.UploadDate = DateOnly.FromDateTime(DateTime.Now);
            db.Thesises.Add(thesise);
            db.SaveChanges();
            //var selected = from p in db.TestUsers
            //              where p.id == 1
            //             select p;
            ////return Json(selected);
            //byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\Никита\\Desktop\\c#\\Краснов Никита.pdf");
            //return File(fileBytes, "application/pdf", "ИмяФайла.pdf");
        }
    }
}