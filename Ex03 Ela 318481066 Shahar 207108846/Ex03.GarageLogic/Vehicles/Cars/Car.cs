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

		internal override void InitializeSpecificInfo(string[] i_SpecificVehicleProperties)
		{
			Color = parseCarColor(i_SpecificVehicleProperties[0]);
			NumberOfDoors = parseNumberOfDoors(i_SpecificVehicleProperties[1]);
		}

		private eCarColor parseCarColor(string i_Color)
		{
			eCarColor carColor;

			try
			{
				carColor = (eCarColor)System.Enum.Parse(typeof(eCarColor), i_Color);
			}
			catch(System.ArgumentException)
			{
				throw new System.FormatException("Invalid car color.");
			}

			return carColor;
		}

		private eNumberOfDoors parseNumberOfDoors(string i_NumberOfDoors)
		{
			eNumberOfDoors numberOfDoors;

			try
			{
				numberOfDoors = (eNumberOfDoors)System.Enum.Parse(typeof(eNumberOfDoors), i_NumberOfDoors);
			}
			catch(System.ArgumentException)
			{
				throw new System.FormatException("Invalid number of doors.");
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

		public override string ToString()
		{
			string carDetails = string.Format(
				"{0}{1}Color: {2}{1}Number of doors: {3}",
				base.ToString(),
				System.Environment.NewLine,
				m_Color,
				m_NumberOfDoors);

			return carDetails;
		}
	}
}
