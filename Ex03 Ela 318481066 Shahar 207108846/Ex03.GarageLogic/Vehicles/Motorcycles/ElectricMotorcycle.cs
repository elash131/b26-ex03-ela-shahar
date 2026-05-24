namespace Ex03.GarageLogic
{
	internal class ElectricMotorcycle : Vehicle
	{
		private ElectricEnergySource m_ElectricEnergySource;
		private eMotorcycleLicenseType m_LicenseType;
		private int m_EngineVolumeInCC;

		public ElectricMotorcycle(string i_LicenseID, string i_ModelName)
		{
			// TODO: Initialize the electric energy source when vehicle constants are wired.
		}

		public override float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_ElectricEnergySource.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}
	}
}
