using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G9.Core;

namespace App_Code.Controler
{
    public class ImageController
    {
        public static string sImg607305
        {
            get { return Config.ImagePath + "/607x305/"; }
        }

        public static string sImg274165
        {
            get { return Config.ImagePath + "/274x165/"; }
        }

        public static string sImg150auto
        {
            get { return Config.ImagePath + "/150xauto/"; }
        }
    }
}
