using Softline.Model.Entity;
using System.Collections.Generic;

namespace Softline.DAL.Repository
{
    public interface IRequestRepository
    {
        void AddRequest(Request request);
        IEnumerable<Request> GetAllRequests();
        void DeleteRequestById(int id);
    }
}
