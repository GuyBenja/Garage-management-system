using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManagementUI
    {
        private bool             m_IsWantToExist = false;
        private GarageVehicles   m_GarageVehicles = new GarageVehicles();
        private GarageManager    m_GarageManager  = new GarageManager();

        public void StartProgram()
        {
            while (!m_IsWantToExist)
            {
                showMenu();
                int userChoice = getUserChoice(1, 8);
                switch (userChoice)
                {
                    case 1:
                        {
                            addOptionOfNewCar();
                            break;
                        }

                    case 2:
                        {
                            getList();
                            break;
                        }

                    case 3:
                        {
                            changeVehicleStatus();
                            break;
                        }

                    case 4:
                        {
                            fillToMaxWheel();
                            break;
                        }

                    case 5:
                        {
                            fuelVehicle();
                            break;
                        }

                    case 6:
                        {
                            chargeVehicle();
                            break;
                        }

                    case 7:
                        {
                            printDetails();
                            break;
                        }

                    case 8:
                        {
                            wantToExist();
                            return;
                        }
                }

                Console.Write("Please press any key to show Menu ...");
                Console.ReadLine();
            }
        }
        private void wantToExist()
        {
            m_IsWantToExist = true;
        }
        private void printDetails()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getLicenseNumber();
                Customer customer = m_GarageManager.TryToGetCustomer(licenseNumber);
                Console.Clear();
                Console.WriteLine(customer.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void chargeVehicle()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getLicenseNumber();

                float maxAmountThatCanBeFilled = ((m_GarageManager.TryToGetCustomer(licenseNumber).Vehicle.EnergySystem.GetHowMuchEnergyCanBeFilled()) * 60);
                float amountOfMin;
                Console.WriteLine(@"For full recharing, please press 1
For manully recharing, please press 2");
                int userChoice = getUserChoice(1, 2);
                switch (userChoice)
                {
                    case 1:
                        {
                            m_GarageManager.ChargeElectricVehicle(licenseNumber, maxAmountThatCanBeFilled);
                            break;
                        }
                    case 2:
                        {
                            float adjustValue = (float)(Math.Round(maxAmountThatCanBeFilled * 100) - 1) / 100;
                            string msg = string.Format($"Please enter the amount of minutes would you like to charge, aware that you can only fill up to {adjustValue} minutes : ");
                            getPositiveFloatInput(msg, out amountOfMin);
                            m_GarageManager.ChargeElectricVehicle(licenseNumber, amountOfMin);
                            break;
                        }
                }
                Console.WriteLine("The vehicle has finished recharging");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine("{0}", vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void fuelVehicle()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getLicenseNumber();
                eTypeFuel typeFuel = reciveTypeFuel();
                float amountOfFuel;
                Console.WriteLine(@"For full refulling, please press 1
For manully refulling, please press 2");
                int userChoice = getUserChoice(1, 2);
                float maxAmountThatCanBeFilled = m_GarageManager.TryToGetCustomer(licenseNumber).Vehicle.EnergySystem.GetHowMuchEnergyCanBeFilled();
                switch (userChoice)
                {
                    case 1:
                        {
                            m_GarageManager.FillRegularVehicle(licenseNumber, typeFuel, maxAmountThatCanBeFilled);
                            break;
                        }
                    case 2:
                        {
                            float adjustedValue = (float)(Math.Round(maxAmountThatCanBeFilled * 100) - 1) / 100;
                            string msg = string.Format($"Please enter the amount of fuel you would like to fill, aware that you can only fill up to {adjustedValue} litters : ");
                            getPositiveFloatInput(msg, out amountOfFuel);
                            m_GarageManager.FillRegularVehicle(licenseNumber, typeFuel, amountOfFuel);
                            break;
                        }
                }
                Console.WriteLine("The vehicle has finished refueling");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void fillToMaxWheel()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getLicenseNumber();
                m_GarageManager.FillAirToMaxPsi(licenseNumber);
                Console.WriteLine("All wheels has been inflated");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void changeVehicleStatus()
        {
            try
            {
                Console.Clear();
                string licenseNumber = getLicenseNumber();
                eStatusVehicle eStatusVehicle = reciveStatusVehicle();
                m_GarageManager.ChangeStatusToVehicle(licenseNumber, eStatusVehicle);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void getList()
        {
            Console.Clear();
            List<string> vehiclesString = null;
            Console.WriteLine(@"Hi please enter you choice:
1.All Vehicles, 
2.Some Vehicles,");
            int userChoice = getUserChoice(1, 2);
            switch (userChoice)
            {
                case 1:
                    {
                        vehiclesString = m_GarageManager.GetListOfAllVehicles();
                        showList(vehiclesString);
                        break;
                    }

                case 2:
                    {
                        eStatusVehicle eStatusVehicle = reciveStatusVehicle();
                        vehiclesString = m_GarageManager.GetFilteredListOfVehicles(eStatusVehicle);
                        showList(vehiclesString);
                        break;
                    }
            }
        }
        private void showList(List<string> i_ListOfStrig)
        {
            Console.Clear();
            Console.WriteLine("Hi this is the list of ID :");
            if(i_ListOfStrig.Count==0)
            {
                Console.WriteLine("There are no matched vehicles in the garage");
                return;
            }
            foreach (string msg in i_ListOfStrig)
            {
                Console.WriteLine("ID : {0}", msg);
            }
        }
        private void showMenu()
        {
            Console.Clear();
            Console.WriteLine(@"********************* Garage Menu *********************

1. To enter a new vehicle into the garage, please press 1
2. To view the list of vehicles in the garage, please press 2 
3. To change the status of a vehicle in the garage, please press 3
4. To inflate all wheels to max the PSI, please press 4
5. To refuel a vehicle that has a fuel energy system, please press 5
6. To charge a vehicle that has an electric energy system, please press 6
7. To get all information about a spceifc vehicle, please press 7
8. To exit, please press 8
");
        }
        private void addOptionOfNewCar()
        {
            Console.Clear();
            int userChoice = 0;
            string licenseNumberStr;

            licenseNumberStr = getLicenseNumber();
            if (m_GarageManager.IsLicenseNumberExist(licenseNumberStr))
            {
                Console.WriteLine("This vehicle is already in the garage");
                m_GarageManager.ChangeStatusToVehicle(licenseNumberStr, eStatusVehicle.InProgress);
            }
            else
            {
                Console.WriteLine("Please choose the type of vehicle:");
                List<string> listOfVehicles = m_GarageVehicles.GetListOfVehicles();
                for (int i = 0; i < listOfVehicles.Count; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, listOfVehicles[i]);
                }

                userChoice = getUserChoice(1, listOfVehicles.Count);
                createCar(listOfVehicles[userChoice - 1], licenseNumberStr);
            }
        }
        private void createCar(string i_Vehicle,string i_LicenseNumber)
        {
            bool isCreationSucceed = false;
            Vehicle vehicleToCreate = null;

            while (!isCreationSucceed)
            {
                try
                {
                    VehicleInfo vehicleInfo = getVehicleInfoToStart(i_LicenseNumber);
                    vehicleToCreate = m_GarageVehicles.GetVehicle(i_Vehicle, vehicleInfo.License, vehicleInfo.NameModel, vehicleInfo.Energy);
                    getVehicleInfoToProgress(vehicleToCreate);
                    isCreationSucceed = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            addToGarage(vehicleToCreate);
        }
        private void addToGarage(Vehicle i_Vehicle)
        {
            string customerName = null;
            string phoneNumber = null;

            Console.Write("Please enter the name of the customer :");
            customerName = Console.ReadLine();
            Console.Write("Please enter the phone number of the customer :");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("The vehicle has been added to the garage");
            m_GarageManager.AddCustomer(i_Vehicle, customerName, phoneNumber);
        }
        private void getVehicleInfoToProgress(Vehicle i_Vehicle)
        {
            bool isVaildParmeters = false;
            VehicleInfo vehicleInfo = i_Vehicle.GetInfoToInput();
            while (!isVaildParmeters)
            {
                foreach (string dataNeedToInput in vehicleInfo.Data)
                {
                    Console.Write(dataNeedToInput);
                    vehicleInfo.Input.Add(Console.ReadLine());
                }

                i_Vehicle.SetInfoToVehicle();
                isVaildParmeters = true;
            }
        }
        private VehicleInfo getVehicleInfoToStart(string i_LicenseNumber)
        {
            VehicleInfo infoOfVehicle = new VehicleInfo();
            Console.Clear();
            Console.Write("Please enter the name of vehicle's model: ");
            infoOfVehicle.NameModel = Console.ReadLine();
            infoOfVehicle.License = i_LicenseNumber;
            infoOfVehicle.Energy = getCurrentEnergy();

            return infoOfVehicle;
        }
        private string getLicenseNumber()
        {
            string msg = string.Empty;

            do
            {
                Console.Write("Hi, please enter the vehicle license number: ");
                msg = Console.ReadLine();
            }
            while (!isLicenseVaild(msg));

            return msg;
        }
        private bool isLicenseVaild(string i_LiescnseNumber)
        {
            bool isVaild = true;

            if (i_LiescnseNumber.Equals(string.Empty))
            {
                isVaild = false;
            }

            foreach (char charToCheck in i_LiescnseNumber)
            {
                if (!char.IsLetterOrDigit(charToCheck))
                {
                    isVaild = false;
                }
            }

            return isVaild;
        }
        private float getCurrentEnergy()
        {
            string msg = string.Empty;
            float numberToConvert = 0;
            bool isValid = false;

            Console.Write("Please enter the current energy in percent:");
            msg = Console.ReadLine();

            isValid = float.TryParse(msg, out numberToConvert);
            if (!isValid || numberToConvert < 0)
            {
                if(numberToConvert>100)
                {
                    throw new ValueOutOfRangeException(100, 0);
                }
                throw new FormatException("You entered an invalid energy percent number, Please try again");
            }

            return numberToConvert;
        }
        private eTypeFuel reciveTypeFuel()
        {
            Console.WriteLine("Type of Fuel : ");
            return (eTypeFuel)receiveEnumChoice(typeof(eTypeFuel));
        }
        private eStatusVehicle reciveStatusVehicle()
        {
            Console.WriteLine("Status of Vehicle : ");
            return (eStatusVehicle)receiveEnumChoice(typeof(eStatusVehicle));
        }
        private Enum receiveEnumChoice(Type i_CurretnEnumType)
        {
            int userChoice;
            Array enumTypes = Enum.GetValues(i_CurretnEnumType);

            Console.Clear();
            foreach (Enum currentType in enumTypes)
            {
                Console.WriteLine("For {0}, press {1}", currentType, currentType.GetHashCode());
            }

            userChoice = getUserChoice(0, enumTypes.Length - 1);

            return (Enum)enumTypes.GetValue(userChoice);
        }
        private int getUserChoice(int i_MinValue, int i_MaxValue)
        {
            bool isVaild = false;
            string msg = string.Empty;
            int numberParsing = 0;

            while (!isVaild)
            {
                Console.Write("Please enter a number in the range {0} - {1} : ", i_MinValue, i_MaxValue);
                msg = Console.ReadLine();
                if (int.TryParse(msg, out numberParsing))
                {
                    isVaild = numberParsing <= i_MaxValue && numberParsing >= i_MinValue;
                }

                if (!isVaild)
                {
                    Console.WriteLine("You entered invalid number, please try again ");
                }
            }

            return numberParsing;
        }
        private void getPositiveFloatInput(string i_Message,out float o_NumberToParse)
        {
            float floatInput;
            string input;
            bool isValid;

            Console.Write(i_Message);
            input = Console.ReadLine();
            isValid = float.TryParse(input, out floatInput);

            if (!isValid || floatInput < 0)
            {
                throw new FormatException("You entered an invalid number, please try again");
            }
            else
            {
                o_NumberToParse = floatInput;
            }
        }
    }
}
