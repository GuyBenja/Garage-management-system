using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string              m_CustomerName = string.Empty;
        private string              m_CustomerPhoneNumber = string.Empty;
        private eStatusVehicle      m_VehicleStatus;
        private Vehicle             m_Vehicle;

        public Customer(string i_CustomerName, string i_CustomerPhoneNumber, Vehicle i_Vehicle)
        {
            m_CustomerName = i_CustomerName;
            m_CustomerPhoneNumber = i_CustomerPhoneNumber;
            m_VehicleStatus = eStatusVehicle.InProgress;
            m_Vehicle = i_Vehicle;
        }
        public string Name
        {
            get
            {
                return m_CustomerName;
            }

            set
            {
                m_CustomerName = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }

            set
            {
                m_CustomerPhoneNumber = value;
            }
        }
        public eStatusVehicle Status
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }
        public override int GetHashCode()
        {
            return m_CustomerPhoneNumber.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();

            vehicleInfo.Append(string.Format("{0}", m_Vehicle.ToString()));
            vehicleInfo.Append(string.Format("Name : {0}{1}", m_CustomerName, Environment.NewLine));
            vehicleInfo.Append(string.Format("Phone Number : {0}{1}", m_CustomerPhoneNumber, Environment.NewLine));
            vehicleInfo.Append(string.Format("Status Of the car : {0}{1}", m_VehicleStatus, Environment.NewLine));

            return vehicleInfo.ToString();
        }
    }
}
