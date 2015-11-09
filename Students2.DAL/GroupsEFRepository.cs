using Students2.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students2.DAL
{
    public class GroupsEFRepository :
        IGroupsRepository
    {
        public IEnumerable<Core.Entities.Group> GetGroups()
        {
            List<Core.Entities.Group> result = 
                new List<Core.Entities.Group>();

            using (StudentsModel context = new StudentsModel())
            {
                foreach(var item in context.Groups)
                {
                    result.Add(new Core.Entities.Group(item.Id, item.Name));
                }
            }

            return result;
        }
    }
}
