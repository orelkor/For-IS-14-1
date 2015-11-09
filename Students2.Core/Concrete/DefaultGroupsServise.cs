using Students2.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students2.Core.Concrete
{
    public class DefaultGroupsServise : GroupsService
    {
        private readonly IGroupsRepository _groupsRepository;

        public DefaultGroupsServise(IGroupsRepository 
            groupsRepository)
        {
            if (groupsRepository == null)
                throw new ArgumentNullException("groupsRepository");

            this._groupsRepository = groupsRepository;
        }

        public override IEnumerable<Entities.Group> Groups()
        {
            return _groupsRepository.GetGroups();
        }
    }
}
