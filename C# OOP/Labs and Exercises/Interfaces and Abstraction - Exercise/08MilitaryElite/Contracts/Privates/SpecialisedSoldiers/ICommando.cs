namespace _08MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    using _08MilitaryElite.Models.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;
    public interface ICommando
    {
        IList<Mission> Missions { get; }
    }
}
