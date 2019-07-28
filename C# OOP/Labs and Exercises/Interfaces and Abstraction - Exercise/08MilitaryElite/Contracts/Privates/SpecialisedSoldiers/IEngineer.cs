namespace _08MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    using _08MilitaryElite.Models.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;
    public interface IEngineer
    {
        IList<Repair> Repairs { get; }
    }
}
