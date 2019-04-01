using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinhard_Engelbrech_Ernie_Scheepers
{
    class InventoryObjects
    {

        private int weight;
        private string name;

        public int Weight { get => weight; set => weight = value; }
        public string Name { get => name; set => name = value; }

        public InventoryObjects(int weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }
    }
}
