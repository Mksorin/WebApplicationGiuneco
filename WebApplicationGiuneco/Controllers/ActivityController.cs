using LoginAndAuth.Controllers;
using LoginAndAuth.Models;
using LoginAndAuth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGiuneco.Models;
using WebApplicationGiuneco.Services;

namespace WebApplicationGiuneco.Controllers
{
    public class ActivityController : Controller, IActionFilter
    {
        //static List<ActivityModel> Activitylist = new List<ActivityModel>();


        //MOSTRO TUTTE LE ATTIVITà
        [HttpGet]
        [Authorization]
        public IActionResult Index()
        {
            ActivityDAO activities = new ActivityDAO();
            //Activitylist.Add(new ActivityModel { Id = 1, Title = "PRova", Description = "questo è un test ", HoursWorked = 30 , Status = Status.Backlog}) ;
            return View(activities.GetAllActivity());
        }
        [HttpGet]
        [Authorization]
        public IActionResult SearchForm()
        {
            return View();
        }
        [HttpGet]
        [Authorization]
        //RICERCO L'ATTIVITà PER IL TITOLO  (ES activity/searchtitle?Title=Goldner%20LLC)
        public IActionResult SearchTitle(string title)
        {
            ActivityDAO activities = new ActivityDAO();
            //List < ActivityModel > activityModelList = activities.SearchActivity(title);
            return View("index", activities.SearchActivity(title));
        }
        [HttpGet]
        [Authorization]
        public IActionResult ViewBacklog()
        {
            ActivityDAO activities = new ActivityDAO();
            UsersDAO user = new UsersDAO();            
            //List < ActivityModel > activityModelList = activities.SearchActivity(title);
            return View("index", activities.SearchActivityByStatus(1,1));
        }
        [HttpGet]
        [Authorization]
        public IActionResult ViewIn_Progress(int id)
        {
            ActivityDAO activities = new ActivityDAO();
            UsersDAO user = new UsersDAO();
            //List < ActivityModel > activityModelList = activities.SearchActivity(title);
            return View("index", activities.SearchActivityByStatus(2, id));
        }
        [HttpGet]
        [Authorization]
        public IActionResult ViewCompletate()
        {
            ActivityDAO activities = new ActivityDAO();
            UsersDAO user = new UsersDAO();
            //List < ActivityModel > activityModelList = activities.SearchActivity(title);
            return View("index", activities.SearchActivityByStatus(3, 1));
        }
        [HttpPost]
        [Authorization]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorization]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        [Authorization]
        public IActionResult Details(int id)
        { ActivityDAO activity = new ActivityDAO();
            ActivityModel activityModel = activity.GetActivityById(id);
            return View(activityModel);
        }
        [HttpGet]
        [Authorization]
        public IActionResult Assegnato(int id)
        {
            ActivityDAO activity = new ActivityDAO();
            UsersDAO user = new UsersDAO();
            return View(activity.SearchUserByActivity(id));
        }
    }
}
