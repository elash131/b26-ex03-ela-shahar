using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		private readonly string r_ModelName;
		private readonly string r_LicenseID;
		private List<Wheel> m_Wheels;
		private readonly Engine r_Engine;

		protected abstract int NumberOfWheels { get; }

		protected abstract float MaxAirPressure { get; }

		public abstract List<string> SpecificPropertyLabels { get; }

		public string LicenseID
		{
			get
			{
				return r_LicenseID;
			}
		}

		internal Vehicle(string i_LicenseID, string i_ModelName, Engine i_Engine)
		{
			r_LicenseID = i_LicenseID;
			r_ModelName = i_ModelName;
			r_Engine = i_Engine;
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
					throw new ValueRangeException("Current wheel air pressure", 0, maxAirPressureToAdd);
				}
				else
				{
					m_CurrentAirPressure += i_AirPressureToAdd;
				}
			}

			internal void InflateToMax()
			{
				Inflate(m_MaxAirPressure - m_CurrentAirPressure);
			}

			public override string ToString()
			{
				string wheelDetails = string.Format(
					"Manufacturer: {0}, Current air pressure: {1}, Max air pressure: {2}",
					m_ManufacturerName,
					m_CurrentAirPressure,
					m_MaxAirPressure);

				return wheelDetails;
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
			r_Engine.InitializeEnergy(i_EnergyPercentage);
		}

		internal abstract void InitializeSpecificInfo(string[] i_SpecificVehicleProperties);

		internal void InflateWheelsToMax()
		{
			foreach(Wheel wheel in m_Wheels)
			{
				wheel.InflateToMax();
			}
		}

		internal void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			r_Engine.Refuel(i_FuelType, i_LitersToAdd);
		}

		internal void Charge(float i_HoursToCharge)
		{
			r_Engine.Charge(i_HoursToCharge);
		}

		public float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = r_Engine.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}

		public override string ToString()
		{
			StringBuilder vehicleDetailsBuilder = new StringBuilder();

			vehicleDetailsBuilder.AppendFormat(
				"License ID: {0}{1}Model name: {2}{1}Remaining energy percentage: {3}{1}",
				r_LicenseID,
				System.Environment.NewLine,
				r_ModelName,
				RemainingEnergyPercentage);
			vehicleDetailsBuilder.AppendLine("Wheels:");

			for(int i = 0; i < m_Wheels.Count; i++)
			{
				vehicleDetailsBuilder.AppendFormat(
					"Wheel {0}: {1}{2}",
					i + 1,
					m_Wheels[i].ToString(),
					System.Environment.NewLine);
			}

			vehicleDetailsBuilder.Append(r_Engine.ToString());

			return vehicleDetailsBuilder.ToString();
		}
	}
}
