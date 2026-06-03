namespace Ex03.GarageLogic
{
	internal class FueledEngine : Engine
	{
		private eFuelType m_FuelType;

		internal FueledEngine(eFuelType i_FuelType, float i_CurrentFuelAmountInLiters, float i_MaxFuelAmountInLiters)
			: base(new EnergySource(i_CurrentFuelAmountInLiters, i_MaxFuelAmountInLiters))
		{
			m_FuelType = i_FuelType;
		}

		internal override void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			if(i_FuelType != m_FuelType)
			{
				throw new System.ArgumentException(
					string.Format(
						"Wrong fuel type. Expected {0}, but received {1}.",
						m_FuelType,
						i_FuelType));
			}
			else
			{
				AddEnergy(i_LitersToAdd);
			}
		}

		public override string ToString()
		{
			string fueledEngineDetails = string.Format(
				"Fuel type: {0}{1}Current fuel amount: {2}{1}Max fuel amount: {3}",
				m_FuelType,
				System.Environment.NewLine,
				CurrentEnergyAmount,
				MaxEnergyAmount);

			return fueledEngineDetails;
		}
	}
}
