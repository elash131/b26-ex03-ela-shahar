namespace Ex03.GarageLogic
{
	internal class ElectricEngine : Engine
	{
		internal ElectricEngine(float i_BatteryTimeLeftInHours, float i_MaxBatteryTimeInHours)
			: base(new EnergySource(i_BatteryTimeLeftInHours, i_MaxBatteryTimeInHours))
		{
		}

		internal override void Charge(float i_HoursToAdd)
		{
			AddEnergy(i_HoursToAdd);
		}

		public override string ToString()
		{
			string electricEngineDetails = string.Format(
				"Battery time left: {0}{1}Max battery time: {2}",
				CurrentEnergyAmount,
				System.Environment.NewLine,
				MaxEnergyAmount);

			return electricEngineDetails;
		}
	}
}
