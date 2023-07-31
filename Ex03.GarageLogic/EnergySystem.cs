using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySystem
    {
        protected float m_EnergyCapacity;
        protected float m_CurrentEnergy;

        public EnergySystem(float i_EnergyCapcity, float i_CurrentEnergy)
        {
            m_CurrentEnergy = i_CurrentEnergy;
            m_EnergyCapacity = i_EnergyCapcity;
        }
        public float EnergyPrecent
        {
            get
            {
                return m_CurrentEnergy / m_EnergyCapacity;
            }
        }
        public float GetHowMuchEnergyCanBeFilled()
        {
            return m_EnergyCapacity - m_CurrentEnergy;
        }
    }
}