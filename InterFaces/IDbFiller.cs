using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ofakim_Project.InterFaces
{
    public interface IDbFiller
    {
         object FillRows(Dictionary<string, object> row);
    }
}