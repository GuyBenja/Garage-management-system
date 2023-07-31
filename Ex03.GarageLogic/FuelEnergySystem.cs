using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEnergySystem : EnergySystem
    {
        protected eTypeFuel m_FuelType;

        public FuelEnergySystem(eTypeFuel i_FuelType, float i_EnergyCapcity, float i_CurrentEnergy)
            : base(i_EnergyCapcity, i_CurrentEnergy)
        {
            m_FuelType = i_FuelType;
        }
        public eTypeFuel FuelType
        {
            get { return m_FuelType; }
        }
        public void FillFuel(float i_FuelToFill, eTypeFuel i_FuelType)
        {
            if (i_FuelType == m_FuelType)
            {
                if (i_FuelToFill + m_CurrentEnergy <= m_EnergyCapacity && i_FuelToFill >= 0 && i_FuelType == m_FuelType)
                {
                    m_CurrentEnergy += i_FuelToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException(m_EnergyCapacity - m_CurrentEnergy, 0);
                }
            }
            else
            {
                throw new ArgumentException("Fuel type does't match");
            }
        }
        public override string ToString()
        {
            return string.Format("Energy system type: fuel, Current fuel: {0}L, Fuel type: {1}", m_CurrentEnergy, m_FuelType);
        }
    }
}