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
            Assert.Same(vehicleParked, vehicleReturned);
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

    public class ParkingBoyShould
    {
        [Fact]
        public void return_a_ticket_when_park_a_vehicle_and_there_is_a_empty_slot_in_one_of_parking_lots()
        {
            var parkingLots = new ParkingLot[1] {new ParkingLot(1)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var fromParkingBoy = parkingBoy.Park(new Vehicle());
            Assert.IsType<Ticket>(fromParkingBoy);
            Assert.Same(parkingLots[0], fromParkingBoy.ParkingLot);
        }

        [Fact]
        public void return_null_when_park_a_vehicle_and_there_no_empty_slot_in_any_parking_lots()
        {
            var parkingLots = new ParkingLot[1] {new ParkingLot(0)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var fromParkingBoy = parkingBoy.Park(new Vehicle());
            Assert.Null(fromParkingBoy);
        }

        [Fact]
        public void park_vehicle_to_parking_lots_according_to_the_given_order()
        {
            var parkingLots = new ParkingLot[2] {new ParkingLot(1), new ParkingLot(1)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var ticket1 = parkingBoy.Park(new Vehicle());
            var ticket2 = parkingBoy.Park(new Vehicle());
            Assert.Same(parkingLots[0], ticket1.ParkingLot);
            Assert.Same(parkingLots[1], ticket2.ParkingLot);
        }

        [Fact]
        public void return_the_correct_vehicle_when_pick_up_with_a_valid_ticket()
        {
            var vehicleParked = new Vehicle();
            var parkingLots = new ParkingLot[1] {new ParkingLot(1)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var ticket = parkingBoy.Park(vehicleParked);
            var vehicleReturned = parkingBoy.PickUp(ticket);
            Assert.Same(vehicleParked, vehicleReturned);
        }

        [Fact]
        public void return_null_when_pick_up_a_vehicle_not_in_any_parking_lot_managed_by_him()
        {
            var vehicleParked = new Vehicle();
            var parkingLots = new ParkingLot[1] {new ParkingLot(1)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var vehicleReturned = parkingBoy.PickUp(new Ticket(parkingLots[0], 0));
            Assert.Null(vehicleReturned);
        }

        [Fact]
        public void return_null_when_pick_up_with_a_ticket_from_a_parking_lot_not_managed_by_him()
        {
            var parkingLots = new ParkingLot[1] {new ParkingLot(1)};
            var parkingBoy = new ParkingBoy(parkingLots);
            var anotherParkingLot = new ParkingLot(1);
            parkingBoy.Park(new Vehicle());
            var ticket = anotherParkingLot.Park(new Vehicle());
            Assert.Null(parkingBoy.PickUp(ticket));
        }
    }
}
