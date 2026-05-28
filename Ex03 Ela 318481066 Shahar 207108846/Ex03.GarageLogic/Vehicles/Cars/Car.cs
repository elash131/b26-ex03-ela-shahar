namespace Ex03.GarageLogic
{
	internal abstract class Car : Vehicle
	{
		private eCarColor m_Color;
		private eNumberOfDoors m_NumberOfDoors;
		private const int k_NumberOfWheels = 5;
		private const float k_MaxAirPressure = 31.0f;

		internal Car(string i_LicenseID, string i_ModelName, Engine i_Engine)
			: base(i_LicenseID, i_ModelName, i_Engine)
		{
		}

		internal eCarColor Color
		{
			get
			{
				return m_Color;
			}

			set
			{
				m_Color = value;
			}
		}

		internal eNumberOfDoors NumberOfDoors
		{
			get
			{
				return m_NumberOfDoors;
			}

			set
			{
				m_NumberOfDoors = value;
			}
		}

		internal override void InitializeSpecificInfo(string[] i_VehicleData)
		{
			Color = parseCarColor(i_VehicleData[k_FirstSpecificInfoIndex]);
			NumberOfDoors = parseNumberOfDoors(i_VehicleData[k_FirstSpecificInfoIndex + 1]);
		}

		private eCarColor parseCarColor(string i_Color)
		{
			eCarColor carColor;

			switch(i_Color)
			{
				case "Red":
					carColor = eCarColor.Red;
					break;
				case "Yellow":
					carColor = eCarColor.Yellow;
					break;
				case "Black":
					carColor = eCarColor.Black;
					break;
				case "Silver":
					carColor = eCarColor.Silver;
					break;
				default:
					throw new System.ArgumentException("Invalid car color.");
			}

			return carColor;
		}

		private eNumberOfDoors parseNumberOfDoors(string i_NumberOfDoors)
		{
			eNumberOfDoors numberOfDoors;

			switch(i_NumberOfDoors)
			{
				case "2":
					numberOfDoors = eNumberOfDoors.Two;
					break;
				case "3":
					numberOfDoors = eNumberOfDoors.Three;
					break;
				case "4":
					numberOfDoors = eNumberOfDoors.Four;
					break;
				case "5":
					numberOfDoors = eNumberOfDoors.Five;
					break;
				default:
					throw new System.ArgumentException("Invalid number of doors.");
			}

			return numberOfDoors;
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
