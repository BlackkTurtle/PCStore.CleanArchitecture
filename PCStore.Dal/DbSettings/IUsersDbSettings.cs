using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Infrastructure.DbSettings
{
    public interface IUsersDbSettings
    {
        string UsersCollectionName { get; }
        string ConnectionStrings { get; }
        string DatabaseName { get; }
    }
}
