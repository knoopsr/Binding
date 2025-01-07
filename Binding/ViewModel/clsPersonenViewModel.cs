using Binding.Common;
using Binding.Helpers;
using Binding.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.IO;


namespace Binding.ViewModel
{
    public class clsPersonenViewModel : clsCommonModelPropertiesBase
    {

        public ICommand cmdDelete { get; set; }
        public ICommand cmdNew { get; set; }
        public ICommand cmdEditPersoon { get; set; }
        public ICommand cmdDrop { get; set; }




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

        private ObservableCollection<clsBestandenModel> _mijnBestanden;
        public ObservableCollection<clsBestandenModel> MijnBestanden
        {
            get { return _mijnBestanden; }
            set
            {

                _mijnBestanden = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            MijnCollectie = new ObservableCollection<clsPersoonModel>();
            MijnBestanden = new ObservableCollection<clsBestandenModel>();


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

            cmdDrop = new clsRelayCommand<object>(executeDrop);


            LoadData();

        }

        private void executeDrop(object obj)
        {
            if (obj is DataObject dataObject && dataObject.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])dataObject.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {  
                    foreach (var file in files)
                    {
                        string bestandNaam = Path.GetFileName(file);
                        MijnBestanden.Add(new clsBestandenModel { BestandsNaam = bestandNaam });
                    }
                }
            }
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
