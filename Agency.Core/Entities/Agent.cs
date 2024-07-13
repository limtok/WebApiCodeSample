namespace Agency.Core
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
    }
}
