namespace Ex03.GarageLogic
{
	internal class ElectricCar : Car
	{
		private const float k_CurrentBatteryTimeInHours = 0.0f;
		private const float k_MaxBatteryTimeInHours = 4.6f;

		internal ElectricCar(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new ElectricEngine(k_CurrentBatteryTimeInHours, k_MaxBatteryTimeInHours))
		{
		}
	}
}
