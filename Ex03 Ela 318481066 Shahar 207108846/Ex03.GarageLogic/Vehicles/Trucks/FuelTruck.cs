namespace Ex03.GarageLogic
{
	internal class FuelTruck : Vehicle
	{
		private bool m_IsCarryingRefrigeratedCargo;
		private float m_CargoVolume;
		private const eFuelType k_FuelType = eFuelType.Soler;
		private const float k_CurrentFuelAmountInLiters = 0.0f;
		private const float k_MaxFuelAmountInLiters = 125.0f;
		private const int k_NumberOfWheels = 14;
		private const float k_MaxAirPressure = 28.0f;

		internal FuelTruck(string i_LicenseID, string i_ModelName)
			: base(i_LicenseID, i_ModelName, new FueledEngine(k_FuelType, k_CurrentFuelAmountInLiters, k_MaxFuelAmountInLiters))
		{
		}

		protected override int NumberOfWheels
		{
			get
			{
				return k_NumberOfWheels;
			}
		}

		protected override float MaxAirPressure
		{
			get
			{
				return k_MaxAirPressure;
			}
		}
	}
}
