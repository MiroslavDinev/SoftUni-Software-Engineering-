namespace _08MilitaryElite.Models.Privates.SpecialisedSoldiers
{
    using _08MilitaryElite.Contracts.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, IList<Mission> missions)
            : base(id,firstName,lastName,salary,corps)
        {
            this.Missions = missions;
        }
        public IList<Mission> Missions { get; }

        public void CompleteMission(string codeName)
        {
            Mission mission = this.Missions.FirstOrDefault(x => x.CodeName == codeName);

            if(mission!=null)
            {
                mission.State = "Finished";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
