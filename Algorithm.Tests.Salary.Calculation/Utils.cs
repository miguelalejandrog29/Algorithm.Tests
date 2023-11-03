namespace Algorithm.Tests.Salary.Calculation
{
    public static class Utils
    {
        public static double CalculateSalary(string startTime, string endTime, double hourlyWage, double overtimeMultiplier)
        {
            const string entryTime = "08:00";
            const string departureTime = "18:00";
            TimeSpan extraWorkHours = new TimeSpan();

            var workHours = DateTime.Parse(departureTime).Subtract(DateTime.Parse(entryTime));
            var startWorkTimeDiference = DateTime.Parse(entryTime).Subtract(DateTime.Parse(startTime));
            var endWorkTimeDiference = DateTime.Parse(departureTime).Subtract(DateTime.Parse(endTime));

            var startDiff = startWorkTimeDiference.CompareTo(TimeSpan.Zero);
            var endDiff = endWorkTimeDiference.CompareTo(TimeSpan.Zero);

            if (startDiff > 0)
            {
                extraWorkHours = extraWorkHours.Add(startWorkTimeDiference.Duration());
            }
            else if (startDiff < 0)
            {
                workHours = workHours.Subtract(startWorkTimeDiference.Duration());
            }

            if (endDiff < 0)
            {
                extraWorkHours = extraWorkHours.Add(endWorkTimeDiference.Duration());
            }
            else if (endDiff > 0)
            {
                workHours = workHours.Subtract(endWorkTimeDiference.Duration());
            }

            return extraWorkHours.TotalHours * overtimeMultiplier + workHours.TotalHours * hourlyWage;
        }
    }
}
