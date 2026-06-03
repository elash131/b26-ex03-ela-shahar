namespace Ex03.GarageLogic
{
	internal abstract class Engine
	{
		private readonly EnergySource r_EnergySource;

		protected Engine(EnergySource i_EnergySource)
		{
			r_EnergySource = i_EnergySource;
		}

		protected void AddEnergy(float i_AmountToAdd)
		{
			r_EnergySource.AddEnergy(i_AmountToAdd);
		}

		internal void InitializeEnergy(float i_EnergyPercentage)
		{
			r_EnergySource.SetCurrentAmountByPercentage(i_EnergyPercentage);
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
				float remainingEnergyPercentage = r_EnergySource.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}

		protected float CurrentEnergyAmount
		{
			get
			{
				return r_EnergySource.CurrentAmount;
			}
		}

		protected float MaxEnergyAmount
		{
			get
			{
				return r_EnergySource.MaxAmount;
			}
		}
	}
}
