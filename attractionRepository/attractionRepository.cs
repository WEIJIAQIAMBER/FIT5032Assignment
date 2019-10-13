using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIT5032Assignment.Models;
using System.Web;

namespace FIT5032Assignment.attractionRepository
{
interface attractionRepository
    {
        IEnumerable<attraction> GetAll();
        attraction Get(int attractionId);
        attraction Add(attraction item);
        attraction Update(attraction item);
        bool Delete(int id);
    }
}