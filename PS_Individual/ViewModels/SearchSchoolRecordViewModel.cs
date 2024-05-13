using Data.Models;
using PS_Individual.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PS_Individual.ViewModels
{
    public class SearchSchoolRecordViewModel : ViewModelBase
    {
        private SchoolRecord schoolRecord;
        private string keyword1;
        private string keyword2;
        private List<SchoolRecord> searchRecordViewModels = new List<SchoolRecord>();

        public CreateRecord createRecordWindow { get; set; }
        public CreateSchoolRecord createSchoolRecordWindow { get; set; }
        public SearchPage searchRecordWindow { get; set; }



        public ICommand SearchCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public ICommand AddSchoolRecordCommand { get; set; }
        public ICommand AddRecordCommand { get; set; }
        public ICommand SerahRecordCommand { get; set; }


        public SearchSchoolRecordViewModel()
        {
            schoolRecord = new SchoolRecord();

            keyword1 = string.Empty;
            keyword1 = string.Empty;

            SearchCommand = new RelayCommand<string>(s => SearchByYear());

            ClearCommand = new RelayCommand<object>(s => Clear());

            AddSchoolRecordCommand = new RelayCommand<object>(s => OpenCreateRecordWindows());
            AddRecordCommand = new RelayCommand<object>(s => OpenCreateSchoolRecordWindows());

            SerahRecordCommand = new RelayCommand<object>(s => OpenSerachRecordWindow());

            createRecordWindow = new CreateRecord();
            createSchoolRecordWindow = new CreateSchoolRecord();

        }


        public int Id
        {
            get => schoolRecord.Id;

            set
            {
                schoolRecord.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Subject
        {
            get => schoolRecord.Subject;

            set
            {
                schoolRecord.Subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public string Conspect
        {
            get => schoolRecord.Conspect;

            set
            {
                schoolRecord.Conspect = value;
                OnPropertyChanged(nameof(Conspect));
            }
        }

        public string Year
        {
            get => schoolRecord.Year.ToString();

            set
            {
                schoolRecord.Year = int.Parse(value);
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

        public List<SchoolRecord> SearchSchoolRecordViewModels
        {
            get => searchRecordViewModels;

            set
            {
                searchRecordViewModels = value;
                OnPropertyChanged(nameof(SearchSchoolRecordViewModels));
            }
        }

        private void SearchByYear()
        {
            SearchSchoolRecordViewModels = new List<SchoolRecord>();

            SearchSchoolRecordDTO searchRecordDTO = new SearchSchoolRecordDTO()
            {
                Subject = this.Subject,
                Keyword1 = this.Keyword1,
                Keyword2 = this.Keyword2,
                Year = this.Year,
                Conspect = this.Conspect,
            };

            var result = schoolRecord.SearchRecords(searchRecordDTO);

            if (result.Count != 0)
            {
                SearchSchoolRecordViewModels = result;
            }

        }

        private void Clear()
        {
            SearchSchoolRecordViewModels = new List<SchoolRecord>();
            Year = "0";
            Keyword1 = string.Empty;
            Keyword2 = string.Empty;
            Subject = string.Empty;
            Conspect = string.Empty;
        }

        private void OpenCreateSchoolRecordWindows()
        {
            createSchoolRecordWindow.Show();
        }

        private void OpenCreateRecordWindows()
        {
            createRecordWindow.Show();

        }

        private void OpenSerachRecordWindow()
        {
            searchRecordWindow.Show();
        }
    }
}
