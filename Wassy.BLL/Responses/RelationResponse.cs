using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL.Responses
{
    public class RelationResponse
    {
        public List<Relation> Relations { get; set; } = new List<Relation>();
    }
    public class RelationMaleResponse
    {
        public List<Relation> RelationMale { get; set; } = new List<Relation>();
    }
    public class RelationFemaleResponse
    {
        public List<Relation> RelationFemale { get; set; } = new List<Relation>();
    }

    public class Relation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
      //  public double Percentage { get; set; }
    }
}
