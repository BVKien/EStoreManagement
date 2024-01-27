using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessObject.Models;

namespace Repository.Members
{
    public class MemberRepository : IMemberRepository
    {
        // Bui Van Kien - 27/01/2024
        // GetMembers 
        public IEnumerable<Member> GetMembers(string id = null, string email = null)
        {
            List<Member> members;
            try
            {
                var dbContext = new eStoreContext();
                members = dbContext.Members.ToList();
                if (!string.IsNullOrEmpty(id))
                {
                    members = members.Where(x => x.MemberId == int.Parse(id)).ToList();
                }
                if (!string.IsNullOrEmpty(email))
                {
                    members = members.Where(x => x.Email.Contains(email)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }


    }
}
