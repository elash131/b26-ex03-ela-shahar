namespace Ex03.GarageLogic
{
	internal class ElectricCar : Vehicle
	{
		private ElectricEnergySource m_ElectricEnergySource;
		private eCarColor m_Color;
		private eNumberOfDoors m_NumberOfDoors;

		public ElectricCar(string i_LicenseID, string i_ModelName)
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
