namespace Ex03.GarageLogic
{
	internal abstract class Engine
	{
		private EnergySource m_EnergySource;

		protected void SetEnergySource(EnergySource i_EnergySource)
		{
			if(i_EnergySource == null)
			{
				throw new System.ArgumentException("Energy source cannot be null.");
			}
			else
			{
				m_EnergySource = i_EnergySource;
			}
		}

		protected void AddEnergy(float i_AmountToAdd)
		{
			m_EnergySource.AddEnergy(i_AmountToAdd);
		}

		internal float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_EnergySource.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}
	}
}
