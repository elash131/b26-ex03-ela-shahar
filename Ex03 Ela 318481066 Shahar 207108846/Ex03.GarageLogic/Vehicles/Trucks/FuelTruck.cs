namespace Ex03.GarageLogic
{
	internal class FuelTruck : Vehicle
	{
		private FuelEnergySource m_FuelEnergySource;
		private bool m_IsCarryingRefrigeratedCargo;
		private float m_CargoVolume;

		public FuelTruck(string i_LicenseID, string i_ModelName)
		{
			// TODO: Initialize the fuel energy source when vehicle constants are wired.
		}

		public override float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_FuelEnergySource.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}
	}
}
