namespace Ex03.GarageLogic
{
	internal class EnergySource
	{
		private float m_CurrentAmount;
		private float m_MaxAmount;

		internal EnergySource(float i_CurrentAmount, float i_MaxAmount)
		{
			if(i_CurrentAmount < 0 || i_CurrentAmount > i_MaxAmount)
			{
				throw new ValueRangeException(0, i_MaxAmount);
			}
			else
			{
				m_CurrentAmount = i_CurrentAmount;
				m_MaxAmount = i_MaxAmount;
			}
		}

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

		internal void SetCurrentAmountByPercentage(float i_EnergyPercentage)
		{
			if(i_EnergyPercentage < 0 || i_EnergyPercentage > 100)
			{
				throw new ValueRangeException(0, 100);
			}
			else
			{
				m_CurrentAmount = (i_EnergyPercentage / 100) * m_MaxAmount;
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

		internal float CurrentAmount
		{
			get
			{
				return m_CurrentAmount;
			}
		}

		internal float MaxAmount
		{
			get
			{
				return m_MaxAmount;
			}
		}
	}
}
