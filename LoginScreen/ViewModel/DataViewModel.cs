using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace LoginScreen
{
	public class DataViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Monkey> MonkeyList { get; set; }

		private bool _busy = false;

		public bool IsBusy
		{
			get { return _busy; }
			set
			{
				if (_busy == value)
					return;
				_busy = value;
				OnPropertyChanged("IsBusy");
			}
		}

		public DataViewModel()
		{
			MonkeyList = new ObservableCollection<Monkey>();
		}

		internal async Task GetDataAsync()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				var client = new HttpClient();

				var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

				var list = JsonConvert.DeserializeObject<List<Monkey>>(json);

				foreach (var item in list)
				{
					MonkeyList.Add(item);
				}
			}
			finally
			{
				IsBusy = false;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string name)
		{
			var propertyChanged = PropertyChanged;
			if(propertyChanged != null)
			{
				propertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}

