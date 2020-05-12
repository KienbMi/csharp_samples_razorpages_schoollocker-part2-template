using CommandLine;
using System;

namespace SchoolLocker.AdminConsole
{
    [Verb("CreateBooking", HelpText = "Create a new Booking for a Locker.")]
    class CreateBookingOptions
    {
        [Option(shortName: 'l', longName: "LockerNumber", Required = true)]
        public int LockerNumber { get; set; }

        [Option(shortName: 'p', longName: "PupilId", Required = true)]
        public int PupilId { get; set; }

        [Option(shortName: 'f', longName: "From", Required = true)]
        public DateTime From { get; set; }

        [Option(shortName: 't', longName: "To", Required = false)]
        public DateTime? To { get; set; }
    }



    [Verb("RetrieveBookings", HelpText = "Retrieve the Bookings for a Locker.")]
    class RetrieveBookingsOptions
    {
        [Option(shortName: 'l', longName: "LockerNumber", Required = true)]
        public int LockerNumber { get; set; }

        [Option(shortName: 'f', longName: "From", Required = true)]
        public DateTime From { get; set; }

        [Option(shortName: 't', longName: "To", Required = false)]
        public DateTime? To { get; set; }
    }



    [Verb("AddLocker", HelpText = "Add a new Locker.")]
    class AddLockerOptions
    {
        [Option(shortName: 'l', longName: "LockerNumber", Required = true)]
        public int LockerNumber { get; set; }
    }

    [Verb("RetrieveLockers", HelpText = "Retrieve the existing Lockers.")]
    class RetrieveLockersOptions
    {
    }


    [Verb("DeleteLocker", HelpText = "Delete an existing Locker.")]
    class DeleteLockerOptions
    {
        [Option(shortName: 'l', longName: "LockerNumber", Required = true)]
        public int LockerNumber { get; set; }
    }

}
