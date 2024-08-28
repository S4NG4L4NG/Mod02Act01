using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod02Act01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Mod02Act01.ViewModel
{
    
    public class StudentModel : INotifyPropertyChanged
    {
        //role of viewmodel
        private Student _student;

        private string _fullName; //variable for data conversion

        public StudentModel()
        {
            //initialized a sample studentm model and coordinate with Model
            _student = new Student { FirstName="John", LastName="Doe", Age=23};
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());


            Students = new ObservableCollection<Student>
            {
                new Student {FirstName="Jane", LastName="Smith", Age=23},
                new Student {FirstName="Juan", LastName="DelaCruz", Age=21},
                new Student {FirstName="Pedro", LastName="Pandecoco", Age=10}
            };

        }

        //setting collection to public
        public ObservableCollection<Student> Students { get; set; }
        
        //two way data binding and data conversion
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }


        //UI thread Management
        public ICommand LoadStudentDataCommand { get; }

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); // I/0 operation
            FullName = $"{_student.FirstName} {_student.LastName}"; //conversion

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    


    }
}
