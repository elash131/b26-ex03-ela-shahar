namespace Ex03.GarageLogic
{
	internal class ElectricEngine : Engine
	{
		internal ElectricEngine(float i_BatteryTimeLeftInHours, float i_MaxBatteryTimeInHours)
			: base(new EnergySource(i_BatteryTimeLeftInHours, i_MaxBatteryTimeInHours))
		{
		}

		internal void Charge(float i_HoursToAdd)
		{
			AddEnergy(i_HoursToAdd);
		}
	}
}
