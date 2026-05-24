namespace Ex03.GarageLogic
{
	internal class ElectricEnergySource
	{
		private float m_BatteryTimeLeftInHours;
		private float m_MaxBatteryTimeInHours;

		internal void Charge(float i_HoursToAdd)
		{
			float maxHoursToAdd = m_MaxBatteryTimeInHours - m_BatteryTimeLeftInHours;

			if(i_HoursToAdd < 0 || i_HoursToAdd > maxHoursToAdd)
			{
				throw new ValueRangeException(0, maxHoursToAdd);
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
