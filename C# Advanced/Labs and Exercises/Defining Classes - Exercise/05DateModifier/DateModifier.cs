namespace _05DateModifier
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class DateModifier
    {
        public string DaysDifference (string firstDate, string secondDate)
        {
            DateTime dateFirst = DateTime.ParseExact(firstDate, "yyyy M d", CultureInfo.InvariantCulture);
            DateTime dateSecond = DateTime.ParseExact(secondDate, "yyyy M d", CultureInfo.InvariantCulture);

            string diff = dateSecond.Subtract(dateFirst).TotalDays.ToString();

            return diff;
        }
    }
}
