using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Students2.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students2.ViewModel
{
    public class GroupViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly GroupsService _groupService;
        private string _name;

        public string Name
        { 
            get { return _name; } 
            set { _name = value; RaisePropertyChanged("Name"); } 
        }

        private RelayCommand _save;
        public ICommand Save
        {
            get
            {
                if (_save == null) _save = new RelayCommand(SaveGroup, ModelIsValid);

                return _save;
            }
        }

        private void SaveGroup()
        {
           
        }

        private bool ModelIsValid()
        {
            if (string.IsNullOrEmpty(Name)) return false;

            return true;
        }

        public GroupViewModel(GroupsService groupService)
        {
            if (groupService == null) throw new ArgumentNullException("groupService");

            this._groupService = groupService;
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get 
            { 
                if(columnName == "Name" && string.IsNullOrEmpty(Name)) return "введите наименование";

                return null;
            }
        }
    }
}
