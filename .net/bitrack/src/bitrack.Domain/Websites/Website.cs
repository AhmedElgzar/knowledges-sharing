using bitrack.Domain.Experiments;
using bitrack.Domain.Goals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Domain.Websites
{
    public class Website: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual List<WebsiteUser> Users { get; set; }
        public List<Goal> Goals { get; set; }

        public void AddUser(WebsiteUser user)
        {
            Users.Add(user);
        }
        public void DeleteUser(WebsiteUser user)
        {
            var websiteUser = Users.Where(u => u.ID == user.ID).Single();
            Users.Remove(websiteUser);
        }
    }
}
