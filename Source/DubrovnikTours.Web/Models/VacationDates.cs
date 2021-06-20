using System;
using System.Collections.Generic;
using System.Linq;

namespace DubrovnikTours.Web.Models
{
    public static class VacationDates
    {
        public static Dictionary<int, IEnumerable<Vacation>> English { get; }
        public static Dictionary<int, IEnumerable<Vacation>> Spanish { get; }

        // hardcoding vacation days as a quick fix
        static VacationDates()
        {
            var year = DateTime.Now.Year;

            var englishFromTos = new[]
            {
                //new FromTo(new DateTime(year, 1, 1), new DateTime(year, 1, 15)),
                //new FromTo(new DateTime(year, 11, 15), new DateTime(year, 12, 31, 23, 59, 59)),
                new FromTo(new DateTime(year, 12, 25), new DateTime(year, 12, 25)),
                new FromTo(new DateTime(year, 12, 25), new DateTime(year, 12, 25)),
            };

            English = GenerateVacationsNext10Years(englishFromTos, year);

            var spanishFromTos = new[]
            {
                //new FromTo(new DateTime(year, 1, 25), new DateTime(year, 4, 1))
                new FromTo(new DateTime(year, 12, 25), new DateTime(year, 12, 25))
            };

            Spanish = GenerateVacationsNext10Years(spanishFromTos, year);
        }

        private static Dictionary<int, IEnumerable<Vacation>> GenerateVacationsNext10Years(FromTo[] fromTos, int year)
        {
            var vacations = new Dictionary<int, IEnumerable<Vacation>>();

            for (var i = 0; i < 10; i++)
            {
                vacations[year] = fromTos.Select(fromTo => CreateVacation(fromTo, year)).ToArray();
                year++;
            }

            return vacations;
        }

        private static Vacation CreateVacation(FromTo fromTo, int year)
        {
            var from = fromTo.From;
            var to = fromTo.To;
            return new Vacation(
                new DateTime(year, from.Month, from.Day, from.Hour, from.Minute, from.Second),
                new DateTime(year, to.Month, to.Day, to.Hour, to.Minute, to.Second)
            );
        }

        private class FromTo
        {
            public DateTime From { get; }
            public DateTime To { get; }

            public FromTo(DateTime from, DateTime to)
            {
                From = from;
                To = to;
            }
        }
    }
}