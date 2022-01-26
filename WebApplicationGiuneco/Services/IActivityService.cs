using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationGiuneco.Models;

namespace WebApplicationGiuneco.Services
{
    interface IActivityService
    {
        List<ActivityModel> GetAllActivity();

        List<ActivityModel> SearchActivity(string searchItem);

        ActivityModel GetActivityById(int Id);

        int Insert(ActivityModel activity);
        int Delete(ActivityModel activity);

        int Update (ActivityModel activity);
    }
}
