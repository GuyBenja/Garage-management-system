using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelTruck : Truck
    {
        public FuelTruck(string i_NameOfModel, string i_LicenseNumber, float i_EnergyPrecent)
            : base(i_NameOfModel, i_LicenseNumber)
        {
            float currentCapcity = i_EnergyPrecent * 135f / 100f;
            m_EnergySystem = new FuelEnergySystem(eTypeFuel.Soler, 135f, currentCapcity);
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Fuel Energy System {0}", Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
