using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eTypeLicense  m_LicenseType;
        protected int           m_EngineVolume;

        internal Motorcycle(string i_NameOfModel, string i_LicenseNumber)
            : base(i_NameOfModel, i_LicenseNumber)
        {
            InitializingWheels(2, 31);
        }
        public eTypeLicense LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }
        public override VehicleInfo GetInfoToInput()
        {
            base.GetInfoToInput();
            m_VehicleInfo.Data.Add("Engine's Volume :");
            m_VehicleInfo.Data.Add("License Type (A1,A2,A,B) :");

            return m_VehicleInfo;
        }
        public override void SetInfoToVehicle()
        {
            base.SetInfoToVehicle();
            if (!int.TryParse(m_VehicleInfo.Input[2], out m_EngineVolume) || m_EngineVolume < 0)
            {
                throw new FormatException("The volume of the engine must be positive integar");
            }
            if (!Enum.TryParse<eTypeLicense>(m_VehicleInfo.Input[3], out eTypeLicense m_LicenseType))
            {
                throw new FormatException("The type of license must be one of these options: A1, A2, A, B");
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("License Type : {0}{1}", m_LicenseType, Environment.NewLine));
            vehicleInfo.Append(string.Format("Engine's Volume : {0}{1}", m_EngineVolume, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
