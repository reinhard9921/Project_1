using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinhard_Engelbrech_Ernie_Scheepers
{
    class Jet
    {
        private string name;
        private double maxSpeed;
        private double maxAltitude;
        private double fuelTankSize;
        private double weightWithInventory;
        private double weightWithoutInventory;
        private List<InventoryObjects> lInventory;

        public double FuelTankSize { get => fuelTankSize; set => fuelTankSize = value; }
        public double WeightWithInventory { get => weightWithInventory; set => weightWithInventory = value; }
        public double WeightWithoutInventory { get => weightWithoutInventory; set => weightWithoutInventory = value; }
        public double TopAltitude { get => maxAltitude; set => maxAltitude = value; }
        public double MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public string Name { get => name; set => name = value; }
        internal List<InventoryObjects> LInventory { get => lInventory; set => lInventory = value; }

        public Jet(string name, double maxSpeed, double maxAltitude, double fuelTankSize, double weightWithoutInventory)
        {
            this.name = name;
            this.maxSpeed = maxSpeed;
            this.maxAltitude = maxAltitude;
            this.fuelTankSize = fuelTankSize;
            this.weightWithoutInventory = weightWithoutInventory;
            lInventory = new List<InventoryObjects>();
        }

        public void CalculateInventoryWeight()
        {
            weightWithInventory = weightWithoutInventory;
            foreach (InventoryObjects item in LInventory)
            {
                weightWithInventory += item.Weight;
            }
        }
    }
}
