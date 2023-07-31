using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEnergySystem : EnergySystem
    {
        public ElectricEnergySystem(float i_EnergyCapcity, float i_CurrentEnergy)
            : base(i_EnergyCapcity, i_CurrentEnergy)
        { }
        public void ChargeBattery(float i_HoursToAdd)
        {
            if (m_CurrentEnergy + i_HoursToAdd <= m_EnergyCapacity && i_HoursToAdd >= 0 && i_HoursToAdd <= m_EnergyCapacity)
            {
                m_CurrentEnergy += i_HoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException((m_EnergyCapacity - m_CurrentEnergy) * 60, 0);
            }
        }
        public override string ToString()
        {
            return string.Format("Energy system type: Electric, Current Battery: {0}h", m_CurrentEnergy);
        }

    }
}
