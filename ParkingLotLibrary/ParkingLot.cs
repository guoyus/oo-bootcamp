using System;

namespace ParkingLotLibrary
{
    public class ParkingLot
    {
        private Vehicle[] slots;
        public int NumberOfEmptySlots { get; private set; }

        public ParkingLot(int capacity)
        {
            slots = new Vehicle[capacity];
            NumberOfEmptySlots = capacity;
        }

        public Ticket Park(Vehicle vehicle)
        {
            if(NumberOfEmptySlots > 0)
            {
                for(int i = 0; i < slots.Length; i++)
                {
                    if(slots[i] == null)
                    {
                        slots[i] = vehicle;
                        NumberOfEmptySlots--;
                        return new Ticket(this, i);
                    }
                }
            }
            return null;
        }

        public Vehicle PickUp(Ticket ticket)
        {
            if(ticket.ParkingLot == this && ticket.SlotId >= 0 && ticket.SlotId < slots.Length && slots[ticket.SlotId] != null)
            {
                var vehicle = slots[ticket.SlotId];
                slots[ticket.SlotId] = null;
                return vehicle;
            }
            return null;
        }
    }

    public class Vehicle
    {

    }

    public class Ticket
    {
        public ParkingLot ParkingLot { get; }
        public int SlotId { get; }

        public Ticket(ParkingLot parkingLot, int slotId)
        {
            ParkingLot = parkingLot;
            SlotId = slotId;
        }
    }

    public abstract class ParkingBoy
    {
        protected ParkingLot[] parkingLots;

        public ParkingBoy(ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public abstract Ticket Park(Vehicle vehicle);

        public Vehicle PickUp(Ticket ticket)
        {
            var idx = Array.IndexOf(parkingLots, ticket.ParkingLot);
            if(idx == -1) return null;
            return parkingLots[idx].PickUp(ticket);
        }
    }

    public class GraduateParkingBoy : ParkingBoy
    {

        public GraduateParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(Vehicle vehicle)
        {
            for(int i = 0; i < parkingLots.Length; i++)
            {
                if(parkingLots[i].NumberOfEmptySlots > 0)
                {
                    return parkingLots[i].Park(vehicle);
                }
            }
            return null;
        }
    }

    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(Vehicle vehicle)
        {
            var maxNumberOfSlots = 0;
            ParkingLot parkingLot = null;
            for(int i = 0; i < parkingLots.Length; i++)
            {
                if(parkingLots[i].NumberOfEmptySlots > maxNumberOfSlots)
                {
                    maxNumberOfSlots = parkingLots[i].NumberOfEmptySlots;
                    parkingLot = parkingLots[i];
                }
            }
            return parkingLot?.Park(vehicle);
        }
    }
}
