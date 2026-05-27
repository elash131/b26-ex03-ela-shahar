using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		private readonly string m_ModelName;
		private readonly string m_LicenseID;
		private List<Wheel> m_Wheels;
		private readonly Engine m_Engine;

		protected abstract int NumberOfWheels { get; }

		protected abstract float MaxAirPressure { get; }

		internal Vehicle(string i_LicenseID, string i_ModelName, Engine i_Engine)
		{
			m_LicenseID = i_LicenseID;
			m_ModelName = i_ModelName;
			m_Engine = i_Engine;
        }

		private class Wheel
		{
			private readonly string m_ManufacturerName;
			private readonly float m_MaxAirPressure;
			private float m_CurrentAirPressure;

			internal Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
			{
                m_ManufacturerName = i_ManufacturerName;
                m_MaxAirPressure = i_MaxAirPressure;

                Inflate(i_CurrentAirPressure);
			}

			internal void Inflate(float i_AirPressureToAdd)
			{
				float maxAirPressureToAdd = m_MaxAirPressure - m_CurrentAirPressure;

				if(i_AirPressureToAdd < 0 || i_AirPressureToAdd > maxAirPressureToAdd)
				{
					throw new ValueRangeException(0, maxAirPressureToAdd);
				}
				else
				{
					m_CurrentAirPressure += i_AirPressureToAdd;
				}
			}

            internal void InflateToMax()
            {
                m_CurrentAirPressure = m_MaxAirPressure;
            }
        }

		internal void InitializeWheels(string i_ManufacturerName, float i_CurrentAirPressure)
		{
			m_Wheels = new List<Wheel>();

			for(int i = 0; i < NumberOfWheels; i++)
			{
				m_Wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, MaxAirPressure));
			}
		}

		internal void InitializeEnergy(float i_EnergyPercentage)
		{
			m_Engine.InitializeEnergy(i_EnergyPercentage);
		}

		internal void InflateWheelsToMax()
		{
			foreach(Wheel wheel in m_Wheels)
			{
                wheel.InflateToMax();
            }
        }

		public float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_Engine.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}
	}
}
