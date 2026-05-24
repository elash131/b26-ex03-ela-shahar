namespace Ex03.GarageLogic
{
	internal class FuelEnergySource
	{
		private eFuelType m_FuelType;
		private float m_CurrentFuelAmountInLiters;
		private float m_MaxFuelAmountInLiters;

		internal void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			if(i_FuelType != m_FuelType)
			{
				// TODO: Throw ArgumentException for wrong fuel type.
			}
			else
			{
				if(m_CurrentFuelAmountInLiters + i_LitersToAdd > m_MaxFuelAmountInLiters)
				{
					// TODO: Throw ValueOutOfRangeException after we implement the custom exception.
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
