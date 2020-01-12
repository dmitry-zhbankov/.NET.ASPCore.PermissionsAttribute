using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.DAL
{
    public class ProfileRepository : IProfileRepository
    {
        private List<Profile> _profiles;

        public ProfileRepository()
        {
            _profiles = new List<Profile>();
            _profiles.Add(new Profile()
            {
                ProfileId = 1,
                Name = "Name 1"
            });
            _profiles.Add(new Profile()
            {
                ProfileId = 1,
                Name = "Name 2"
            });
            _profiles.Add(new Profile()
            {
                ProfileId = 1,
                Name = "Name 3"
            });
        }

        public IEnumerable<Profile> Get(Expression<Func<Profile, bool>> filter)
        {
            var res = _profiles.Where(filter.Compile());
            return res;
        }

        public Profile GetById(int id)
        {
            var profile = _profiles.Find(x => x.ProfileId == id);
            return profile;
        }

        public void Create(Profile entity)
        {
            _profiles.Add(entity);
        }

        public void Delete(int id)
        {
            var profile = GetById(id);
            _profiles.Remove(profile);
        }

        public void Update(Profile entity)
        {
            var profile = GetById(entity.ProfileId);
            profile.Name = entity.Name;
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
