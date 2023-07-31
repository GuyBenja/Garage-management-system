using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageVehicles
    {
        private readonly List<string> r_AllVehicles;

        public GarageVehicles()
        {
            r_AllVehicles = new List<string>();
            r_AllVehicles.Add("Fuel Bike");
            r_AllVehicles.Add("Electric Bike");
            r_AllVehicles.Add("Fuel Car");
            r_AllVehicles.Add("Electric Car");
            r_AllVehicles.Add("Fuel Truck");
        }
        public List<string> GetListOfVehicles()
        {
            return r_AllVehicles;
        }
        public Vehicle GetVehicle(string i_VehicleType, string i_LicenseNumber, string i_NameOfModel, float i_EnergyPrecent)
        {
            Vehicle vehicle = null;

            if (i_VehicleType.Equals("Fuel Bike"))
            {
                vehicle = new FuelMotorcycle(i_NameOfModel, i_LicenseNumber, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Electric Bike"))
            {
                vehicle = new ElectricMotorcycle(i_NameOfModel, i_LicenseNumber, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Fuel Car"))
            {
                vehicle = new FuelCar(i_NameOfModel, i_LicenseNumber, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Electric Car"))
            {
                vehicle = new ElectricCar(i_NameOfModel, i_LicenseNumber, i_EnergyPrecent);
            }
            else if (i_VehicleType.Equals("Fuel Truck"))
            {
                vehicle = new FuelTruck(i_NameOfModel, i_LicenseNumber, i_EnergyPrecent);
            }
            else
            {
                throw new FormatException("The vehicle type doesn't exist");
            }

            return vehicle;
        }
    }
}
