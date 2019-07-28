namespace _08MilitaryElite.Models.Privates
{
    using _08MilitaryElite.Contracts.Privates;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IList<Private> privates) 
            : base(id,firstName,lastName,salary)
        {
            this.Privates = privates;
        }

        public IList<Private> Privates { get; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Privates:");

            foreach (var @private in this.Privates)
            {
                stringBuilder.AppendLine("  " + @private.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
