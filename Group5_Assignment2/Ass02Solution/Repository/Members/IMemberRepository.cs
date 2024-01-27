using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace Repository.Members
{
    public interface IMemberRepository
    {
        // Bui Van Kien - 27/01/2024 
        IEnumerable<Member> GetMembers(string id = null, string email = null);
    }
}
