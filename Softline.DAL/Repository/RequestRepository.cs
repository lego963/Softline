using Softline.DAL.Context;
using Softline.Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Softline.DAL.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RequestRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddRequest(Request request)
        {
            applicationDbContext.Requests.Add(request);
            applicationDbContext.SaveChanges();
        }

        public void DeleteRequestById(int id)
        {
            var requestToDelete = applicationDbContext.Requests.FirstOrDefault(req => req.Id == id);
            if (requestToDelete != null)
            {
                applicationDbContext.Requests.Remove(requestToDelete);
            }
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return applicationDbContext.Requests;
        }
    }
}