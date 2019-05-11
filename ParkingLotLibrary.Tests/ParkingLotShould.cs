using System;
using Xunit;

namespace ParkingLotLibrary.Tests
{
    public class ParkingLotShould
    {
        private readonly ParkingLot _parkingLot;

        public ParkingLotShould()
        {
            _parkingLot = new ParkingLot(1);
        }

        [Fact]
        public void return_a_ticket_when_park_a_vehicle_and_there_is_a_empty_slot()
        {
            var fromParkingLot = _parkingLot.Park(new Vehicle());
            Assert.IsType<Ticket>(fromParkingLot);
        }

        [Fact]
        public void return_null_when_park_a_vehicle_and_there_is_a_empty_slot()
        {
            _parkingLot.Park(new Vehicle());
            var fromParkingLot = _parkingLot.Park(new Vehicle());
            Assert.Null(fromParkingLot);
        }

        [Fact]
        public void return_the_correct_vehicle_when_pick_up_with_a_valid_ticket()
        {
            var vehicleParked = new Vehicle();
            var ticket = _parkingLot.Park(vehicleParked);
            var vehicleReturned = _parkingLot.PickUp(ticket);
            Assert.Equal(vehicleParked, vehicleReturned);
        }

        [Fact]
        public void return_null_when_pick_up_a_vehicle_not_in_the_lot()
        {
            var vehicleReturned = _parkingLot.PickUp(new Ticket(_parkingLot, 0));
            Assert.Null(vehicleReturned);
        }

        [Fact]
        public void return_null_when_pick_up_with_a_ticket_from_other_parking_lots()
        {
            var anotherParkingLot = new ParkingLot(3);
            _parkingLot.Park(new Vehicle());
            var vehicleReturned = _parkingLot.PickUp(new Ticket(anotherParkingLot, 0));
            Assert.Null(vehicleReturned);
        }
    }
}
