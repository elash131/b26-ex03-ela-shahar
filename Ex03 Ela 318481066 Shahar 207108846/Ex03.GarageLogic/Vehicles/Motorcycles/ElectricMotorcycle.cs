namespace Ex03.GarageLogic
{
	internal class ElectricMotorcycle : Motorcycle
	{
		private const float k_CurrentBatteryTimeInHours = 0.0f;
		private const float k_MaxBatteryTimeInHours = 3.0f;

		internal ElectricMotorcycle(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new ElectricEngine(k_CurrentBatteryTimeInHours, k_MaxBatteryTimeInHours))
		{
		}
	}
}
