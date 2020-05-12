using CommandLine;
using System.Threading.Tasks;

namespace SchoolLocker.AdminConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<
                    CreateBookingOptions,
                    RetrieveBookingsOptions,
                    AddLockerOptions,
                    RetrieveLockersOptions,
                    DeleteLockerOptions>(args)
                .MapResult(
                    (CreateBookingOptions opts) => CreateBookingAsync(opts).Result,
                    (RetrieveBookingsOptions opts) => RetrieveBookingsAsync(opts).Result,
                    (AddLockerOptions opts) => AddLockerAsync(opts).Result,
                    (RetrieveLockersOptions opts) => RetrieveLockersAsync(opts).Result,
                    (DeleteLockerOptions opts) => DeleteLockerAsync(opts).Result,
                    errs => 1);
        }


        private static async Task<int> CreateBookingAsync(CreateBookingOptions opts)
        {
            //TODO: Logik zum Erstellen von Buchungen implementieren (inkl. Validierungen!)
            return 0;
        }

        private static async Task<int> RetrieveBookingsAsync(RetrieveBookingsOptions opts)
        {
            //TODO: Logik zum Abfragen von Buchungen implementieren
            return 0;
        }

        private static async Task<int> AddLockerAsync(AddLockerOptions opts)
        {
            //TODO: Logik zum Hinzufügen eines neuen Spinds implementieren (inkl. Validierungen!)
            return 0;
        }

        private static async Task<int> RetrieveLockersAsync(RetrieveLockersOptions opts)
        {
            //TODO: Logik zum Abfragen der Spinde implementieren
            return 0;
        }

        private static async Task<int> DeleteLockerAsync(DeleteLockerOptions opts)
        {
            //TODO: Logik zum Löschen eines Spinds implementieren
            return 0;
        }
    }
}
