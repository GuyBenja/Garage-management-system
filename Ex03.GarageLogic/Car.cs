using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eColorOfCar       m_ColorOfCar;
        protected eNumberOfDoors    m_NumberOfDoors;

        internal Car(string i_NameOfModel, string i_LicenseNumber)
            : base(i_NameOfModel, i_LicenseNumber)
        {
            InitializingWheels(5, 33);
        }
        public eColorOfCar Color
        {
            get { return m_ColorOfCar; }
        }
        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }
        public override VehicleInfo GetInfoToInput()
        {
            base.GetInfoToInput();
            m_VehicleInfo.Data.Add("Car's Color (White, Black, Yellow, Red): ");
            m_VehicleInfo.Data.Add("Door's Number (Two, Three, Four, Five): ");

            return m_VehicleInfo;
        }
        public override void SetInfoToVehicle()
        {
            base.SetInfoToVehicle();
            if (!Enum.TryParse<eColorOfCar>(m_VehicleInfo.Input[2], out eColorOfCar m_ColorOfCar))
            {
                throw new FormatException("The color of the car must be one of these options: White, Black, Yellow, Red");
            }
            if (!Enum.TryParse<eNumberOfDoors>(m_VehicleInfo.Input[3], out eNumberOfDoors m_NumberOfDoors))
            {
                throw new FormatException("The number of doors must be one of these options: Two, Three, Four, Five");
            }
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", base.ToString()));
            vehicleInfo.Append(string.Format("Color of the car : {0}{1}", m_ColorOfCar, Environment.NewLine));
            vehicleInfo.Append(string.Format("Number of doors in the car : {0}{1}", m_NumberOfDoors, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
