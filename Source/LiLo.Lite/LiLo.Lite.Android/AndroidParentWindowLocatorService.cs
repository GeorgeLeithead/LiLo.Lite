namespace LiLo.Lite.Droid
{
	using LiLo.Lite.Interfaces;
	using Plugin.CurrentActivity;

	internal class AndroidParentWindowLocatorService : IParentWindowLocatorService
	{
		public object GetCurrentParentWindow()
		{
			return CrossCurrentActivity.Current.Activity;
		}
	}
}