using System.Collections.Generic;
using System.ComponentModel;
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
			Teams = Utils.DummyDataProvider.GetTeams();
			RefreshCommand = new Command(CmdRefresh);
			Columns = new ColumnCollection
			{
//				new DataGridColumn {Title = "Logo", PropertyName = "Logo"},
				new DataGridColumn {Title = "Team", PropertyName = "Name"},
				new DataGridColumn {Title = "Win", PropertyName = "Win"},
				new DataGridColumn {Title = "Loose", PropertyName = "Loose"},
				new DataGridColumn {Title = "Home", PropertyName = "Home"},
				new DataGridColumn {Title = "Percentage", PropertyName = "Percentage"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
				new DataGridColumn {Title = "Streak", PropertyName = "Streak"},
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
