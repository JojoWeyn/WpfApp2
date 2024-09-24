using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class EditViewModel : NotifyPropertyChanged
    {
        private Employee _employee;
        private List<Employee> _employees;
        private List<Position> _positions;

        public Employee Employee
        {
            get => _employee;
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged(nameof(Employee));
                }
            }
        }

        public List<Employee> Employees
        {
            get => _employees;
            set
            {
                if (_employees != value)
                {
                    _employees = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }
        }

        public List<Position> Positions
        {
            get => _positions;
            set
            {
                if (_positions != value)
                {
                    _positions = value;
                    OnPropertyChanged(nameof(Positions));
                }
            }
        }

        private readonly AppDbContext _appDbContext;

        public EditViewModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Employees = _appDbContext.Employees.ToList();
            Positions = _appDbContext.Positions.ToList();
            Employee = Employees.FirstOrDefault() ?? new Employee();
        }

        private RelayCommand _EditCommand = null!;
        public RelayCommand EditCommand
        {
            get => _EditCommand ?? (_EditCommand = new RelayCommand((obj) =>
            {
                _appDbContext.SaveChanges();
            }));
        }
    }
}