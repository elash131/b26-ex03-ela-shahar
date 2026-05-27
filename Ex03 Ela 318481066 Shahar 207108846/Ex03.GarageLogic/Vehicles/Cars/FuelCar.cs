namespace Ex03.GarageLogic
{
	internal class FuelCar : Car
	{
		private const eFuelType k_FuelType = eFuelType.Octan95;
		private const float k_CurrentFuelAmountInLiters = 0.0f;
		private const float k_MaxFuelAmountInLiters = 51.0f;

		internal FuelCar(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new FueledEngine(k_FuelType, k_CurrentFuelAmountInLiters,
				k_MaxFuelAmountInLiters))
		{
		}
	}
}
