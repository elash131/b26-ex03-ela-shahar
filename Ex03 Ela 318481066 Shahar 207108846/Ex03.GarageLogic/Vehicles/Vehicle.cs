using System.Collections.Generic;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		private string m_ModelName;
		private string m_LicenseID;
		private List<Wheel> m_Wheels;
		private Engine m_Engine;

		internal void SetEngine(Engine i_Engine)
		{
			if(i_Engine == null)
			{
				throw new System.ArgumentException("Engine cannot be null.");
			}
			else
			{
				m_Engine = i_Engine;
			}
		}

		public float RemainingEnergyPercentage
		{
			get
			{
				float remainingEnergyPercentage = m_Engine.RemainingEnergyPercentage;

				return remainingEnergyPercentage;
			}
		}
	}
}
