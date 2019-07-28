namespace _08MilitaryElite.Contracts.Privates
{
    using _08MilitaryElite.Models;
    using System.Collections.Generic;
    public interface ILieutenantGeneral
    {
        IList<Private> Privates { get; }
    }
}
