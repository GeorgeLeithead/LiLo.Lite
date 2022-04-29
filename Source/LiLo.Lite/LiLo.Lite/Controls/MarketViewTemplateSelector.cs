namespace LiLo.Lite.Controls
{
	using LiLo.Lite.Helpers;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Runtime based data template selector for market view.</summary>
	public class MarketViewTemplateSelector : DataTemplateSelector
	{
		/// <summary>Gets or sets the data template for compact view.</summary>
		public DataTemplate CompactView { get; set; }

		/// <summary>Gets or sets the data template for magazine view.</summary>
		public DataTemplate MagazineView { get; set; }

		/// <summary>Return the user selected data template.</summary>
		/// <param name="item">The data for which to return a template.</param>
		/// <param name="container">An optional container object in which the developer may have opted to store Xamarin.Forms.DataTemplateSelector objects.</param>
		/// <returns>A developer-defined Xamarin.Forms.DataTemplate that can be used to display item.</returns>
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			return Preferences.Get(Constants.Preferences.Settings.MarketsView, Constants.Preferences.Settings.MarketsViewDefaulyValue) ? MagazineView : CompactView;
		}
	}
}