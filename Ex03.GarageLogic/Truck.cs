using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool    m_HazardousMaterials = false;
        private float   m_TrunkVolume;

        internal Truck(string i_NameOfModel, string i_LicenseNumber)
            : base(i_NameOfModel, i_LicenseNumber)
        {
            InitializingWheels(14, 26);
        }
        public bool Materials
        {
            get { return m_HazardousMaterials; }
        }
        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
        }
        public override VehicleInfo GetInfoToInput()
        {
            base.GetInfoToInput();
            m_VehicleInfo.Data.Add("Hazardous Materials (true | false): ");
            m_VehicleInfo.Data.Add("Trunk's Volume :");

            return m_VehicleInfo;
        }
        public override void SetInfoToVehicle()
        {
            base.SetInfoToVehicle();
            if (!bool.TryParse(m_VehicleInfo.Input[2], out m_HazardousMaterials))
            {
                throw new FormatException("The option for Hazardous Materials must be true or false");
            }
            if (!float.TryParse(m_VehicleInfo.Input[3], out m_TrunkVolume))
            {
                throw new FormatException("The volume of the trunk must be positive float");
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Fuel Energy System {0}", Environment.NewLine));
            vehicleInfo.Append(string.Format("Hazardous Materials : {0}{1}", m_HazardousMaterials, Environment.NewLine));
            vehicleInfo.Append(string.Format("Trunk's Volume : {0}{1}", m_TrunkVolume, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
