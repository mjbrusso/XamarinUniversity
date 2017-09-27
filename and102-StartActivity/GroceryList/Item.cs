namespace GroceryList
{
	public class Item
	{
		public string Name  { get; set; }
		public long   Count { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}