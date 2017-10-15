using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL
{
    public class TemplateResponse
    {
        public List<Template> Templates { get; set; } = new List<Template>();

    }
    public class Template
    {
        public string wassaya { set; get; }
        public int Id { set; get; }
    }
}

