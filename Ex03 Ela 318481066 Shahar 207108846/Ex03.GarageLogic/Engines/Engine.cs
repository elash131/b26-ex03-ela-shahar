namespace Ex03.GarageLogic
{
	internal abstract class Engine
	{
		private EnergySource m_EnergySource;

		protected Engine(EnergySource i_EnergySource)
		{
			SetEnergySource(i_EnergySource);
		}

		protected void SetEnergySource(EnergySource i_EnergySource)
		{
			m_EnergySource = i_EnergySource;
		}

		protected void AddEnergy(float i_AmountToAdd)
		{
			m_EnergySource.AddEnergy(i_AmountToAdd);
		}

		internal void InitializeEnergy(float i_EnergyPercentage)
		{
			m_EnergySource.SetCurrentAmountByPercentage(i_EnergyPercentage);
		}

		internal virtual void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			throw new System.ArgumentException("Vehicle is not fuel based.");
		}

		internal virtual void Charge(float i_HoursToCharge)
		{
			throw new System.ArgumentException("Vehicle is not electric.");
		}

		internal float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_EnergySource.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}

		protected float CurrentEnergyAmount
		{
			get
			{
				return m_EnergySource.CurrentAmount;
			}
		}

		protected float MaxEnergyAmount
		{
			get
			{
				return m_EnergySource.MaxAmount;
			}
		}
	}
}
