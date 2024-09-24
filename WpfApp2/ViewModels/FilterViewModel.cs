using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class FilterViewModel : NotifyPropertyChanged
    {
        private List<Employee> Employees { get; set; }
        public List<Employee> FiltredEmployees { get; set; }
        public string Filter { get; set; } = string.Empty;

        private readonly AppDbContext _appDbContext;
        public FilterViewModel(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
            Employees = _appDbContext.Employees.ToList();
            FiltredEmployees = Employees;
        }

        RelayCommand _FilterCommand;
        public RelayCommand FilterCommand
        {
            get => _FilterCommand ?? (_FilterCommand = new RelayCommand((obj) =>
            {
                FiltredEmployees = Employees.FindAll(e => e.FullName.Contains(Filter));
                OnPropertyChanged(nameof(FiltredEmployees));
            }));
            

        }
    }
}
