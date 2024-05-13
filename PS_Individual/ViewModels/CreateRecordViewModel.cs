using Data.Database;
using Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PS_Individual.ViewModels
{
    public class CreateRecordViewModel : ViewModelBase
    {
        private Record record;
        public ICommand CreateRecordCommand { get; set; }

        public CreateRecordViewModel()
        {
            CreateRecordCommand = new RelayCommand<Record>(s => CreateRecord(record));
            record = new Record();
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

        public string Title
        {
            get => record.Title;

            set
            {
                record.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        public string Author
        {
            get => record.Author;

            set
            {
                record.Author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public string Description
        {
            get => record.Description;

            set
            {
                record.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Topic
        {
            get => record.Topic;

            set
            {
                record.Topic = value;
                OnPropertyChanged(nameof(Topic));
            }
        }

        public string SubTopic
        {
            get => record.SubTopic;

            set
            {
                record.SubTopic = value;
                OnPropertyChanged(nameof(SubTopic));
            }
        }

        public string Product
        {
            get => record.Product;

            set
            {
                record.Product = value;
                OnPropertyChanged(nameof(Product));
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

        private void CreateRecord(Record record)
        {
            if (record.Create(record)) 
            {
                MessageBox.Show("Successfully created a new record!", "Record", MessageBoxButton.OK, MessageBoxImage.Information);

                Title = string.Empty;
                Description = string.Empty;
                Author = string.Empty;
                SubTopic = string.Empty;
                Topic = string.Empty;
                Year = 0;
                Product = string.Empty;

            }
        }
    }
}
