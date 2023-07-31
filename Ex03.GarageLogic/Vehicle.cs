using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string     r_NameOfModel = string.Empty;
        private readonly string     r_LicenseNumber = string.Empty;
        protected EnergySystem      m_EnergySystem = null;
        protected List<Wheel>       m_Wheels = null;
        protected VehicleInfo       m_VehicleInfo;

        internal Vehicle(string i_NameOfModel, string i_LicenseNumber)
        {
            this.r_NameOfModel = i_NameOfModel;
            this.r_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
            m_VehicleInfo = new VehicleInfo();
        }
        public override bool Equals(object obj)
        {
            bool toCompare = false;

            if (obj is Vehicle vehicle)
            {
                toCompare = vehicle.r_LicenseNumber == this.r_LicenseNumber;
            }

            return toCompare;
        }
        public EnergySystem EnergySystem
        {
            get
            {
                return m_EnergySystem;
            }
        }
        protected void InitializingWheels(int i_CountOfWheels, int i_MaxPressuer)
        {
            for (int i = 0; i < i_CountOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxPressuer));
            }
        }
        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
        public bool CheckLicense(string i_LicenseToCheck)
        {
            return r_LicenseNumber == i_LicenseToCheck;
        }
        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }
        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }
        public virtual VehicleInfo GetInfoToInput()
        {
            m_VehicleInfo.Data.Add("Wheels Manufacturer :");
            m_VehicleInfo.Data.Add("Wheels Current PSI :");

            return m_VehicleInfo;
        }
        public virtual void SetInfoToVehicle()
        {
            string wheelManufacturer = m_VehicleInfo.Input[0];
            bool isValid;
            float floatInput;

            foreach (Wheel wheel in m_Wheels)
            {
                wheel.NameManufacuter = wheelManufacturer;
            }

            isValid = float.TryParse(m_VehicleInfo.Input[1], out floatInput);

            if (!isValid || floatInput < 0)
            {
                throw new FormatException("The wheels PSI must be a positive float");
            }
            else
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    if (floatInput > wheel.MaxPsi)
                    {
                        throw new ValueOutOfRangeException(wheel.MaxPsi, 0);
                    }
                    wheel.CurrentPsi = floatInput;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            int currentIndex = 1;

            vehicleInfo.Append(string.Format("License number: {0}{1}", r_LicenseNumber, Environment.NewLine));
            vehicleInfo.Append(string.Format("Model name: {0}{1}", r_NameOfModel, Environment.NewLine));
            vehicleInfo.Append(string.Format("{0}{1}", m_EnergySystem.ToString(), Environment.NewLine));
            vehicleInfo.Append(string.Format("Wheels: {0}", Environment.NewLine));
            foreach (Wheel currentWheel in m_Wheels)
            {
                vehicleInfo.Append(string.Format("Wheel {0}: {1}{2}", currentIndex, currentWheel.ToString(), Environment.NewLine));
                currentIndex++;
            }

            return vehicleInfo.ToString();
        }
    }
}
