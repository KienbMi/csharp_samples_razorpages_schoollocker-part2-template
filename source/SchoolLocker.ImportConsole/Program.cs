using SchoolLocker.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLocker.ImportConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Import der Schüler, Spinde und Buchungen in die Datenbank");
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Console.WriteLine("Datenbank löschen");
                await unitOfWork.DeleteDatabaseAsync();
                Console.WriteLine("Datenbank migrieren");
                await unitOfWork.MigrateDatabaseAsync();
                Console.WriteLine("Buchungen werden von schoollocker.csv eingelesen");
                var bookings = ImportController.ReadFromCsv().ToArray();
                if (bookings.Length == 0)
                {
                    Console.WriteLine("!!! Es wurden keine Buchungen eingelesen");
                    return;
                }

                Console.WriteLine(
                    $"  Es wurden {bookings.Count()} Buchungen eingelesen, werden in Datenbank gespeichert ...");
                await unitOfWork.BookingRepository.AddRangeAsync(bookings);
                int countPupils = bookings.GroupBy(b => b.Pupil).Count();
                int countLockers = bookings.GroupBy(b => b.Locker).Count();
                int savedRows = await unitOfWork.SaveChangesAsync();
                Console.WriteLine(
                    $"{countLockers} Spinde, {countPupils} Schüler und {savedRows - countLockers - countPupils} Buchungen wurden in Datenbank gespeichert!");
                Console.WriteLine();
                Console.Write("Beenden mit Eingabetaste ...");
                Console.ReadLine();
            }
        }
    }
}
