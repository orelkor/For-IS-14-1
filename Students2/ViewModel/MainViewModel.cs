using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Students2.Core.Abstract;
using Students2.Core.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Students2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly GroupsService _groupsService;

        public ObservableCollection<Group> Groups
        {
            get
            {
                return new ObservableCollection<Group>(_groupsService.Groups());
            }
        }

        private RelayCommand _addOpen;
        public ICommand AddOpen
        {
            get
            {
                if (_addOpen == null)
                    _addOpen = new RelayCommand(() => 
                    {
                        Students2.View.Group win = new Students2.View.Group();
                        win.Show();
                    });

                return _addOpen;
            }
        }

        public MainViewModel(GroupsService groupsService)
        {
            if (groupsService == null) throw new ArgumentNullException("groupsService");

            this._groupsService = groupsService;
        }
    }
}