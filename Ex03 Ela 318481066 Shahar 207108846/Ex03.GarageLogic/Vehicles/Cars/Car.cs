using System.Collections.Generic;

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
			if(!System.Enum.TryParse(i_Color, out eCarColor carColor)
				|| !System.Enum.IsDefined(typeof(eCarColor), carColor))
			{
				throw new System.FormatException(string.Format("'{0}' is not a valid car color.", i_Color));
			}

			return carColor;
		}

		private eNumberOfDoors parseNumberOfDoors(string i_NumberOfDoors)
		{
			if(!System.Enum.TryParse(i_NumberOfDoors, out eNumberOfDoors numberOfDoors)
				|| !System.Enum.IsDefined(typeof(eNumberOfDoors), numberOfDoors))
			{
				throw new System.FormatException(string.Format("'{0}' is not a valid number of doors.", i_NumberOfDoors));
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

		public override List<string> SpecificPropertyLabels
		{
			get
			{
				return new List<string>
				{
					string.Format(
						"car color ({0})",
						string.Join(", ", System.Enum.GetNames(typeof(eCarColor)))),
					"number of doors (2, 3, 4, 5)"
				};
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
