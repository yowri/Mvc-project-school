using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMvC.DataModels;

namespace ProjectMvC.Models
{
    public class SerializedModelSpeler
    {
        //
        // GET: /SerializedModel/

        public int Id { get; set; }
        public string naam { get; set; }
        public string flag { get; set; }
        public Nullable<int> score { get; set; }
        public string platform { get; set; }


    }
}
