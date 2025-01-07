using Binding.Common;
using Binding.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Binding.ViewModel
{
    public class clsPersonenViewModel : clsCommonModelPropertiesBase
    {

        public ICommand cmdDelete { get; set; }
        public ICommand cmdNew { get; set; }
        public ICommand cmdEditPersoon { get; set; }
 



        private ObservableCollection<clsPersoonModel> _mijnCollectie;
        public ObservableCollection<clsPersoonModel> MijnCollectie
        {
            get { return _mijnCollectie; }
            set
            {
                _mijnCollectie = value;
                OnPropertyChanged();
            }
        }

        private clsPersoonModel _mijnSelectedItem;
        public clsPersoonModel MijnSelectedItem
        {
            get { return _mijnSelectedItem; }
            set
            {

                _mijnSelectedItem = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            MijnCollectie = new ObservableCollection<clsPersoonModel>();

            MijnCollectie.Add(new clsPersoonModel { PersoonID = 1, Naam = "Janssens", Voornaam = "Jan" });
            MijnCollectie.Add(new clsPersoonModel { PersoonID = 2, Naam = "Peeters", Voornaam = "Piet" });
            MijnCollectie.Add(new clsPersoonModel { PersoonID = 3, Naam = "Janssens", Voornaam = "Jef" });
            MijnCollectie.Add(new clsPersoonModel { PersoonID = 4, Naam = "Peeters", Voornaam = "Jef" });
        }



        public clsPersonenViewModel()
        {
            cmdEditPersoon = new clsRelayCommand<object>(executeEditPersoon);
            cmdDelete = new clsRelayCommand<object>(executeDelete);
            cmdNew = new clsRelayCommand<object>(executeNew);


            LoadData();

        }

        private void executeNew(object obj)
        {
            if (obj is clsPersoonModel)
            {
                MessageBox.Show("New PersoonID: " + (obj as clsPersoonModel).PersoonID.ToString());
            }
        }

        private void executeDelete(object obj)
        {
            if (obj is clsPersoonModel)
            {
                MessageBox.Show("Delete PersoonID: " + (obj as clsPersoonModel).PersoonID.ToString());
            }
        }

        private void executeEditPersoon(object obj)
        {
            if (obj is clsPersoonModel)
            {
                MessageBox.Show("Edit PersoonID: " + (obj as clsPersoonModel).PersoonID.ToString());
            }
        }
    }
}
