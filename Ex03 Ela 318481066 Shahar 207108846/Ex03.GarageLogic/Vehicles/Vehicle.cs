using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		private string m_ModelName;
		private string m_LicenseID;
		private List<Wheel> m_Wheels;

		public abstract float RemainingEnergyPercentage
		{
			get;
		}
	}
}
