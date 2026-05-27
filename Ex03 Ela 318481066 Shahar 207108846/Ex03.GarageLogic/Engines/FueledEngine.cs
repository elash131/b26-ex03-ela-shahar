namespace Ex03.GarageLogic
{
	internal class FueledEngine : Engine
	{
		private eFuelType m_FuelType;

		internal void Refuel(eFuelType i_FuelType, float i_LitersToAdd)
		{
			if(i_FuelType != m_FuelType)
			{
				throw new System.ArgumentException("Wrong fuel type.");
			}
			else
			{
				AddEnergy(i_LitersToAdd);
			}
		}
	}
}
