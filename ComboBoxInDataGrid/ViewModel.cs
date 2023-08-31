using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxInDataGrid
{
    public enum Status
    {
        Status1,
        Status2,
        Status3
    }

    public class Data : NotifyBase
    {
        public string Name { get; private set; }

        private Status _status;
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public Data(string name)
        {
            Name = name;
            Status = Status.Status1;
        }
    }

    public class ViewModel : NotifyBase
    {
        private ObservableCollection<Data> _sokAdat;
        public ObservableCollection<Data> SokAdat
        {
            get
            {
                return _sokAdat;
            }
            set
            {
                _sokAdat = value;
                OnPropertyChanged();
            }
        }

        public ViewModel()
        {
            SokAdat = new ObservableCollection<Data>();
            SokAdat.Add(new Data("Data1"));
            SokAdat.Add(new Data("Data2"));
            SokAdat.Add(new Data("Data3"));
            SokAdat.Add(new Data("Data4"));
        }
    }
}
