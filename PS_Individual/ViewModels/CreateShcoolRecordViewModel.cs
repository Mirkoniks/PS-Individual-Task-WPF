using Data.Database;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PS_Individual.ViewModels
{
    public class CreateShcoolRecordViewModel : ViewModelBase
    {
        private SchoolRecord record;
        public ICommand CreateRecordCommand { get; set; }

        public CreateShcoolRecordViewModel()
        {
            record = new SchoolRecord(); 
            CreateRecordCommand = new RelayCommand<SchoolRecord>(s => CreateRecord(record));
            Subject = string.Empty;
            Conspect = string.Empty;
        }
        public int Id
        {
            get => record.Id;

            set
            {
                record.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Subject
        {
            get => record.Subject;

            set
            {
                record.Subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }


        public string Conspect
        {
            get => record.Conspect;

            set
            {
                record.Conspect = value;
                OnPropertyChanged(nameof(Conspect));
            }
        }

        public int Year
        {
            get => record.Year;

            set
            {
                record.Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        private void CreateRecord(SchoolRecord record)
        {
            if (record.Create(record))
            {
                MessageBox.Show("Successfully created a new school record!", "Record", MessageBoxButton.OK, MessageBoxImage.Information);

                Year = 0;
                Subject = string.Empty;
                Conspect = string.Empty;
            }
        }
    }
}
