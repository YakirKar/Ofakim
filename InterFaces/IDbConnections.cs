using Ofakim_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ofakim_Project.InterFaces
{
    public interface IDbConnections
    {
        DbConnection CreateDbConnection();
    }
}