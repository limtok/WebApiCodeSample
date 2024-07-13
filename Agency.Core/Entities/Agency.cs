using System;
using System.Collections.Generic;

namespace Agency.Core
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public virtual IList<Agent> Agents { get; set; }
    }
}
