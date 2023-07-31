using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private List<string>    m_DataNeedToGet = new List<string>();
        private List<string>    m_InputFromUser = new List<string>();
        private string          m_NameOfModel = string.Empty;
        private string          m_LicenseNumber = string.Empty;
        private float           m_EnergyPrecent;

        private bool checkIfEnergyPercentIsVaild()
        {
            if (m_EnergyPrecent >= 0 && m_EnergyPrecent <= 100)
            {
                return true;
            }
            else
            {
                throw new ValueOutOfRangeException(100, 0);
            }
        }
        private bool checkIfModelNameIsVaild()
        {
            if (m_NameOfModel.Equals(string.Empty) == false)
            {
                return true;
            }
            else
            {
                throw new FormatException("Empty Field Name Please try again");
            }
        }
        private bool checkIfLiceneIsVaild()
        {
            bool isVaild = true;

            if (m_LicenseNumber.Equals(string.Empty))
            {
                throw new FormatException("Empty Field License Please try again");
            }

            foreach (char charToCheck in m_LicenseNumber)
            {
                if (char.IsLetterOrDigit(charToCheck) == false)
                {
                    isVaild = false;
                }
            }

            return isVaild;
        }
        public string License
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
                checkIfLiceneIsVaild();
            }
        }
        public string NameModel
        {
            get
            {
                return m_NameOfModel;
            }

            set
            {
                m_NameOfModel = value;
                checkIfModelNameIsVaild();
            }
        }
        public float Energy
        {
            get
            {
                return m_EnergyPrecent;
            }

            set
            {
                m_EnergyPrecent = value;
                checkIfEnergyPercentIsVaild();
            }
        }
        public List<string> Data
        {
            get
            {
                return m_DataNeedToGet;
            }
        }
        public List<string> Input
        {
            get
            {
                return m_InputFromUser;
            }
        }
    }
}