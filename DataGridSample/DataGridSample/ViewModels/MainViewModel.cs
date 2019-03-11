using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using DataGridSample.Models;
using Xamarin.Forms;
using Xamarin.Forms.DataGrid;

namespace DataGridSample.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{

		#region fields
		private List<Team> teams;
		private Team selectedItem;
		private bool isRefreshing;
		#endregion

		#region Properties


		public ICommand ClickCommand { get; set; }
		public ICommand ClickCellCommand { get; set; }

		private ColumnCollection _columns;

		public ColumnCollection Columns
		{
			get => _columns;
			set { _columns = value; OnPropertyChanged(nameof(Columns)); }
		}

		public List<Team> Teams
		{
			get { return teams; }
			set { teams = value; OnPropertyChanged(nameof(Teams)); }
		}

		public Team SelectedTeam
		{
			get { return selectedItem; }
			set
			{
				selectedItem = value;
				System.Diagnostics.Debug.WriteLine("Team Selected : " + value?.Name);
			}
		}

		public bool IsRefreshing
		{
			get { return isRefreshing; }
			set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); }
		}

		public ICommand RefreshCommand { get; set; }
		#endregion

		public MainViewModel()
		{
			ClickCommand = new Command(s =>
			{
				Debug.WriteLine("Hello world!");
			});

			ClickCellCommand = new Command(s =>
			{
				Debug.WriteLine("Hello! " + s);
			});
			Teams = Utils.DummyDataProvider.GetTeams();
			RefreshCommand = new Command(CmdRefresh);
			Columns = new ColumnCollection
			{
//				new DataGridColumn {Title = "Logo", PropertyName = "Logo"},
				new DataGridColumn {Title = "Deadline", PropertyName = "Name"},
				new DataGridColumn {Title = "Contractor", PropertyName = "Win"},
				new DataGridColumn {Title = "Craft", PropertyName = "Loose"},
				new DataGridColumn {Title = "Resp. person", PropertyName = "Home"},
				new DataGridColumn {Title = "Field", PropertyName = "Percentage"},
				new DataGridColumn {Title = "Building", PropertyName = "Streak"},
				new DataGridColumn {Title = "Level", PropertyName = "Streak"},
				new DataGridColumn {Title = "Room", PropertyName = "Streak"},
				new DataGridColumn {Title = "Axis/Position", PropertyName = "Streak"},
				new DataGridColumn {Title = "Type of defect", PropertyName = "Streak"},
				new DataGridColumn {Title = "Priority", PropertyName = "Streak"},
				new DataGridColumn {Title = "costs", PropertyName = "Streak"},
				new DataGridColumn {Title = "imported on", PropertyName = "Streak"},
				new DataGridColumn {Title = "imported at", PropertyName = "Streak"},
			};
		}

		private async void CmdRefresh()
		{
			IsRefreshing = true;
			// wait 3 secs for demo
			await Task.Delay(3000);
			IsRefreshing = false;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}

		#endregion
	}
}
