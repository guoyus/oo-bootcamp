using System;

namespace ParkingLotLibrary
{
    public class ParkingLot
    {
        private Vehicle[] slots;

        public ParkingLot(int size)
        {
            slots = new Vehicle[size];
        }

        public Ticket Park(Vehicle vehicle)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if(slots[i] == null)
                {
                    slots[i] = vehicle;
                    return new Ticket(this, i);
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
}
