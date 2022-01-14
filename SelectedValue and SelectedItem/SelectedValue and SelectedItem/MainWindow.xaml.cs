using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SelectedValue_and_SelectedItem
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow 
	{
		public MainWindow()
		{
			// Initialzing our data
			ShapeCollection = GetShapesList();
			PropertiesList  = GetPropertiesList();

			InitializeComponent();
		}

		public ObservableCollection<MyShape> ShapeCollection { get; set; }
		public ObservableCollection<PropertyObject> PropertiesList { get; set; }

		#region Static Initialization helpers

		private static ObservableCollection<MyShape> GetShapesList()
		{
			return new ObservableCollection<MyShape> {	
				new MyShape{ShapeType = "Circle",    ShapeColor = "Blue",	ShapeSides = 0 },
				new MyShape{ShapeType = "Triangle",  ShapeColor = "Yellow",	ShapeSides = 3 }, 
				new MyShape{ShapeType = "Square",    ShapeColor = "Red",	ShapeSides = 4 },
				new MyShape{ShapeType = "Pentagon",  ShapeColor = "Black",	ShapeSides = 5 },
				new MyShape{ShapeType = "Hexagon",   ShapeColor = "White",	ShapeSides = 6 },
				new MyShape{ShapeType = "Hectagon",  ShapeColor = "Green",	ShapeSides = 8 },
				new MyShape{ShapeType = "Decagon",   ShapeColor = "Gray",	ShapeSides = 10}
			};
		}

		private static ObservableCollection<PropertyObject> GetPropertiesList()
		{
			ObservableCollection<PropertyObject> return_collection 
				= new ObservableCollection<PropertyObject> { new PropertyObject {PropertyName = "", PropertyType = "Reset to default"} };

			var propertiesInfos = typeof(MyShape).GetProperties();
			foreach (var propertyInfo in propertiesInfos)
			{
				return_collection.Add(new PropertyObject { PropertyName = propertyInfo.Name, 
														   PropertyType = propertyInfo.PropertyType.Name });
			}

			return return_collection;
		}

		#endregion

		#region Comboboxes selection changed events
		/// <summary>
		/// This will change the SourceListBox DisplayMemberPath property.
		/// </summary>
		private void DisplayMemberPathCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cmbx = (ComboBox)sender;
			PropertyObject prop_ob = ((PropertyObject)cmbx.SelectedItem);
			string name = prop_ob.PropertyName;
			SourceListBox.DisplayMemberPath = name;
		}

		/// <summary>
		/// This will change the SourceListBox SelectedValuePath property.
		/// </summary>
		private void ShapeClassPropertiesCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cmbx = (ComboBox)sender;
			PropertyObject prop_ob = ((PropertyObject)cmbx.SelectedItem);
			string name = prop_ob.PropertyName;
			var item_index = SourceListBox.SelectedIndex;
			SourceListBox.SelectedValuePath = null;		// without this, we get a null exceptions when going from string to int properties for some reason.
			SourceListBox.SelectedValuePath = name;
			SourceListBox.SelectedIndex = item_index;
		}

		#endregion

		#region Open hyperlink event
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		} 
		#endregion
	}

	/// <summary>
	/// Dummy Class for our ObservableCollection
	/// </summary>
	public class MyShape
	{
		public string ShapeType  { get; set; }
		public string ShapeColor { get; set; }
		public int	  ShapeSides { get; set; }

		// Using this in order to see what the objects holds when DisplayMemberPath is not set
		public override string ToString()
		{
			return string.Format("MyShape Object <{0},{1},{2}>", ShapeType, ShapeSides, ShapeColor);
		}
	}

	/// <summary>
	/// The Combo boxes lists are instances of this class.
	/// </summary>
	public class PropertyObject
	{
		public string PropertyName { get; set; }
		public string PropertyType { get; set; }

		// Using this in order to see what the objects holds when DisplayMemberPath is not set
		public override string ToString()
		{
			return string.Format("{0}   ({1})", PropertyName, PropertyType);
		}
	}
}
