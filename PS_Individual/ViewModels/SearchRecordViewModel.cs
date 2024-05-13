using Data.Models;
using Data.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Reflection.Metadata;
using PS_Individual.Components;

namespace PS_Individual.ViewModels
{
    public class SearchRecordViewModel : ViewModelBase
    {
        private Record record;

        private string keyword1;
        private string keyword2;
        private List<Record> searchRecordViewModels = new List<Record>();

        public CreateRecord createRecordWindow { get; set; }
        public CreateSchoolRecord createSchoolRecordWindow { get; set; }
        public SearchSchoolRecordPage searchSchoolRecordWindow{ get; set; }


        public ICommand SearchCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public ICommand AddSchoolRecordCommand { get; set; }
        public ICommand AddRecordCommand { get; set; }

        public ICommand SerahSchoolRecordCommand { get; set; }



        public SearchRecordViewModel()
        {
            record = new Record();

            Keyword1 = string.Empty;
            Keyword2 = string.Empty;

            SearchCommand = new RelayCommand<string>(s => SearchByYear());

            ClearCommand = new RelayCommand<object>(s => Clear());

            AddSchoolRecordCommand = new RelayCommand<object>(s => OpenCreateRecordWindows());
            AddRecordCommand = new RelayCommand<object>(s => OpenCreateSchoolRecordWindows());

            SerahSchoolRecordCommand = new RelayCommand<object>(s => OpenSerachSchoolRecordWindow());

            createRecordWindow = new CreateRecord();
            createSchoolRecordWindow = new CreateSchoolRecord();

            searchSchoolRecordWindow = new SearchSchoolRecordPage();

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

        public string Year
        {
            get => record.Year.ToString();

            set
            {
                record.Year = int.Parse(value);
                OnPropertyChanged(nameof(Year));
            }
        }

        public string Keyword1
        {
            get => keyword1;

            set
            {
                keyword1 = value;
                OnPropertyChanged(nameof(Keyword1));
            }
        }

        public string Keyword2
        {
            get => keyword2;

            set
            {
                keyword2 = value;
                OnPropertyChanged(nameof(Keyword2));
            }
        }

        public List<Record> SearchRecordViewModels
        {
            get => searchRecordViewModels;

            set
            {
                searchRecordViewModels = value;
                OnPropertyChanged(nameof(SearchRecordViewModels));
            }
        }

        private void SearchByYear() 
        {
            SearchRecordViewModels = new List<Record>();

            SearchRecordDTO searchRecordDTO = new SearchRecordDTO()
            { 
                SubTopic = this.SubTopic,
                Product = this.Product,
                Author = this.Author,
                Description = this.Description,
                Keyword1 = this.Keyword1,
                Keyword2 = this.Keyword2,
                Year = this.Year,
                Title = this.Title,
                Topic = this.Topic,
            };

            var result = record.SearchRecords(searchRecordDTO);

            if (result.Count != 0) 
            {
                SearchRecordViewModels = result;
            }

        }

        private void Clear()
        {
            SearchRecordViewModels = new List<Record>();
            Title = string.Empty;
            Description = string.Empty;
            Author = string.Empty;
            SubTopic = string.Empty;
            Topic = string.Empty;
            Year = "0";
            Product = string.Empty;
            Keyword1 = string.Empty;
            Keyword2 = string.Empty;
        }

        private void OpenCreateSchoolRecordWindows() 
        {
            createSchoolRecordWindow.Show();
        }

        private void OpenCreateRecordWindows() 
        {
            createRecordWindow.Show();

        }

        private void OpenSerachSchoolRecordWindow()
        {
            searchSchoolRecordWindow.Show();
        }

    }
}
