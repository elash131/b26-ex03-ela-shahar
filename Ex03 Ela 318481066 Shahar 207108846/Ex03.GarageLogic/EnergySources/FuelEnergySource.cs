namespace Ex03.GarageLogic
{
	internal class FuelEnergySource
	{
		private eFuelType m_FuelType;
		private float m_CurrentFuelAmountInLiters;
		private float m_MaxFuelAmountInLiters;

		internal void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			float maxLitersToAdd = m_MaxFuelAmountInLiters - m_CurrentFuelAmountInLiters;

			if(i_FuelType != m_FuelType)
			{
				throw new System.ArgumentException("Wrong fuel type.");
			}
			else
			{
				if(i_LitersToAdd < 0 || i_LitersToAdd > maxLitersToAdd)
				{
					throw new ValueRangeException(0, maxLitersToAdd);
				}
				else
				{
					m_CurrentFuelAmountInLiters += i_LitersToAdd;
				}
			}
		}

		internal float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = (m_CurrentFuelAmountInLiters / m_MaxFuelAmountInLiters) * 100;

				return remainingEnergyPercentage;
			}
		}
	}
}
