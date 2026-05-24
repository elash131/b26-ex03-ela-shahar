namespace Ex03.GarageLogic
{
	internal class ElectricEnergySource
	{
		private float m_BatteryTimeLeftInHours;
		private float m_MaxBatteryTimeInHours;

		internal void Charge(float i_HoursToAdd)
		{
			if(m_BatteryTimeLeftInHours + i_HoursToAdd > m_MaxBatteryTimeInHours)
			{
				// TODO: Throw ValueOutOfRangeException after we implement the custom exception.
			}
			else
			{
				m_BatteryTimeLeftInHours += i_HoursToAdd;
			}
		}

		internal float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = (m_BatteryTimeLeftInHours / m_MaxBatteryTimeInHours) * 100;

				return remainingEnergyPercentage;
			}
		}
	}
}
