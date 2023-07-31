using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Customer> r_Customers;

        public GarageManager()
        {
            r_Customers = new Dictionary<string, Customer>();
        }
        public void AddCustomer(Vehicle i_Vehicle, string i_Name, string i_PhoneNumber)
        {
            if (IsLicenseNumberExist(i_Vehicle.LicenseNumber))
            {
                throw new ArgumentException("The Vehicle already exists");
            }
            else
            {
                r_Customers.Add(i_Vehicle.LicenseNumber, new Customer(i_Name, i_PhoneNumber, i_Vehicle));
            }
        }
        public bool IsLicenseNumberExist(string i_LicenseNumber)
        {
            return r_Customers.ContainsKey(i_LicenseNumber);
        }
        public List<string> GetListOfAllVehicles()
        {
            return new List<string>(r_Customers.Keys);
        }
        public List<string> GetFilteredListOfVehicles(eStatusVehicle i_StatusVehicles)
        {
            List<string> filteredList = new List<string>();

            foreach (Customer customer in r_Customers.Values)
            {
                if (customer.Status == i_StatusVehicles)
                {
                    filteredList.Add(customer.Vehicle.LicenseNumber);
                }
            }

            return filteredList;
        }
        public void ChangeStatusToVehicle(string i_LicenseNumber, eStatusVehicle i_StatusVehicle)
        {
            Customer customers = TryToGetCustomer(i_LicenseNumber);
            Console.WriteLine("The vehicle status has change from {0} to {1}", customers.Status, i_StatusVehicle);
            customers.Status = i_StatusVehicle;
        }
        public void FillAirToMaxPsi(string i_LicenseNumber)
        {
            Customer customer = TryToGetCustomer(i_LicenseNumber);

            foreach (Wheel wheel in customer.Vehicle.Wheels)
            {
                wheel.FillAirPressure(wheel.MaxPsi - wheel.CurrentPsi);
            }
        }
        public void FillRegularVehicle(string i_LicenseNumber, eTypeFuel i_FuelType, float i_AmountToFill)
        {
            Customer customer = TryToGetCustomer(i_LicenseNumber);

            if (customer.Vehicle.EnergySystem is FuelEnergySystem fuelEnergy)
            {
                fuelEnergy.FillFuel(i_AmountToFill, i_FuelType);
            }
            else
            {
                throw new FormatException("This vehicle doesn't have fuel energy system");
            }
        }
        public void ChargeElectricVehicle(string i_LicenseNumber, float i_AmountMinToCharge)
        {
            float realNumberInHours = i_AmountMinToCharge / 60f;
            Customer customer = TryToGetCustomer(i_LicenseNumber);

            if (customer.Vehicle.EnergySystem is ElectricEnergySystem electricEnergySystem)
            {
                electricEnergySystem.ChargeBattery(realNumberInHours);
            }
            else
            {
                throw new FormatException("This vehicle doesn't have electric energy system");
            }
        }
        public Customer TryToGetCustomer(string i_LicenseNumber)
        {
            Customer o_Customer;
            bool isExists = r_Customers.TryGetValue(i_LicenseNumber, out o_Customer);

            if (isExists)
            {
                return o_Customer;
            }
            else
            {
                throw new ArgumentException("The license number isn't exist");
            }
        }
    }
}
