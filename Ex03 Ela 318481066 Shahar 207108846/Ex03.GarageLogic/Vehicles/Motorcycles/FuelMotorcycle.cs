namespace Ex03.GarageLogic
{
	internal class FuelMotorcycle : Vehicle
	{
		private FuelEnergySource m_FuelEnergySource;
		private eMotorcycleLicenseType m_LicenseType;
		private int m_EngineVolumeInCC;

		public FuelMotorcycle(string i_LicenseID, string i_ModelName)
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
