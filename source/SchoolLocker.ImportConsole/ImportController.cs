using System;
using System.Collections.Generic;
using System.Linq;
using SchoolLocker.Core.Entities;
using Utils;

namespace SchoolLocker.ImportConsole
{
    public class ImportController
    {
        const string Filename = "schoollocker.csv";

        /// <summary>
        /// Liefert die Buchungen mit den dazugehörigen Schülern und Spinden
        /// </summary>
        public static IEnumerable<Booking> ReadFromCsv()
        {
            string[][] matrix = MyFile.ReadStringMatrixFromCsv(Filename, true);
            List<Locker> lockers = matrix
                .GroupBy(line => line[2])
                .Select(grp => new Locker { Number = int.Parse(grp.Key) })
                .ToList();
            List<Pupil> pupils = matrix
                .GroupBy(line => line[0]+"_"+line[1])
                .Select(grp => new Pupil { LastName = grp.First()[0], FirstName = grp.First()[1]})
                .ToList();
            List<Booking> bookings = matrix.Select(line => new Booking
            {
                Pupil = pupils.Single(pupil => line[0]==pupil.LastName && line[1] == pupil.FirstName),
                Locker = lockers.Single(locker => locker.Number == int.Parse(line[2])),
                From = DateTime.Parse(line[3]),
                To = line[4].Length > 0 ? DateTime.Parse(line[4]) : (DateTime?) null
            }).ToList();
            return bookings;
        }

    }
}
