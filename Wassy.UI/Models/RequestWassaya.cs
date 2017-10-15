using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wassy.UI.Models
{
    public class RequestWassaya
    {
        public string wassaya;
        int id;
        
        public RequestWassaya(string wassayaa, int Id)
        {
            id = Id;
            wassaya = wassayaa;
        }
        public int getID ()
        {
            return id;
        }
        public string getWassaya()
        {
            return wassaya;
        }



    }
}