namespace Ex03.GarageLogic
{
	internal class FuelMotorcycle : Motorcycle
	{
		private const eFuelType k_FuelType = eFuelType.Octan98;
		private const float k_CurrentFuelAmountInLiters = 0.0f;
		private const float k_MaxFuelAmountInLiters = 5.6f;

		internal FuelMotorcycle(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new FueledEngine(k_FuelType, k_CurrentFuelAmountInLiters, k_MaxFuelAmountInLiters))
		{
		}
	}
}
