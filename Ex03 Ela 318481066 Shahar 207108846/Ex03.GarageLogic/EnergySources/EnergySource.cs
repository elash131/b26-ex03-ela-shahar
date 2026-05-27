namespace Ex03.GarageLogic
{
	internal abstract class EnergySource
	{
		private float m_CurrentAmount;
		private float m_MaxAmount;

		internal void AddEnergy(float i_AmountToAdd)
		{
			float maxAmountToAdd = m_MaxAmount - m_CurrentAmount;

			if(i_AmountToAdd < 0 || i_AmountToAdd > maxAmountToAdd)
			{
				throw new ValueRangeException(0, maxAmountToAdd);
			}
			else
			{
				m_CurrentAmount += i_AmountToAdd;
			}
		}

		internal float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = (m_CurrentAmount / m_MaxAmount) * 100;

				return remainingEnergyPercentage;
			}
		}
	}
}
