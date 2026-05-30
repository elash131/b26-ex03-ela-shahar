using System;

namespace Ex03.GarageLogic
{
	public class ValueRangeException : Exception
	{
		private readonly float r_MinValue;
		private readonly float r_MaxValue;

		public ValueRangeException(string i_Message, float i_MinValue, float i_MaxValue)
			: base(i_Message)
		{
			r_MinValue = i_MinValue;
			r_MaxValue = i_MaxValue;
		}

		public float MinValue
		{
			get
			{
				return r_MinValue;
			}
		}

		public float MaxValue
		{
			get
			{
				return r_MaxValue;
			}
		}
	}
}
