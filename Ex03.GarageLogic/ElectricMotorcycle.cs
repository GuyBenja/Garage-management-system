using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        internal ElectricMotorcycle(string i_NameOfModel, string i_LicenseNumber, float i_EnergyPrecent)
            : base(i_NameOfModel, i_LicenseNumber)
        {
            float currentCapcity = i_EnergyPrecent * 2.6f / 100f;
            m_EnergySystem = new ElectricEnergySystem(2.6f, currentCapcity);
            m_VehicleInfo = new VehicleInfo();
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Electric Energy System {0}", Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
