namespace Ex03.GarageLogic
{
	internal class FuelCar : Vehicle
	{
		private FuelEnergySource m_FuelEnergySource;
		private eCarColor m_Color;
		private eNumberOfDoors m_NumberOfDoors;

		public FuelCar(string i_LicenseID, string i_ModelName)
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
