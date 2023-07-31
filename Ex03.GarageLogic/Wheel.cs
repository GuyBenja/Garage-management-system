using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string          m_NameOfManufacturer;
        private float           m_CurrentAirPressure;
        private readonly float  r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            this.r_MaxAirPressure = i_MaxAirPressure;
        }
        public void FillAirPressure(float i_AirToFill)
        {
            if (i_AirToFill + m_CurrentAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure - m_CurrentAirPressure, 0);
            }
        }
        public string NameManufacuter
        {
            get
            {
                return m_NameOfManufacturer;
            }

            set
            {
                m_NameOfManufacturer = value;
            }
        }
        public float CurrentPsi
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxPsi
        {
            get
            {
                return r_MaxAirPressure;
            }
        }
        public override string ToString()
        {
            return string.Format("Manufacturer's name: {0}{2}Current air pressure: {1}", m_NameOfManufacturer, m_CurrentAirPressure, Environment.NewLine);
        }
    }
}
