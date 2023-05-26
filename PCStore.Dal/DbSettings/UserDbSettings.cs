using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Infrastructure.DbSettings
{
    public class UserDbSettings : IUsersDbSettings
    {
        public string UsersCollectionName { get; } = String.Empty;

        public string ConnectionStrings { get; }=String.Empty;

        public string DatabaseName { get; }=String.Empty;
    }
}
