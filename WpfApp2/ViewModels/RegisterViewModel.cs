using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class RegisterViewModel : NotifyPropertyChanged
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty ;
        public decimal Salary { get; set; } = 0;
        public Position Position { get; set; }
        public List <Position> Positions { get; set; }


        private readonly AppDbContext _appDbContext;


        public RegisterViewModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext; 
            Positions = _appDbContext.Positions.ToList();
        }

        private RelayCommand _RegCommand = null!;
        public RelayCommand RegCommand
        {
            get => _RegCommand ?? (_RegCommand = new RelayCommand((obj) => {
                Login = Login.Trim();
                Password = Password.Trim();
                if (_appDbContext.Users.Any(u => u.Login == Login) || Login == null || Password == null) 
                {
                    MessageBox.Show("lfyyst ujdyj");
                } 
                else
                {
                    _appDbContext.Users.Add(new User { Login = Login, Password = Password, RoleId = 2, Employee = new Employee { FullName = FullName, PositionId = Position.Id, Salary = Salary } });
                    _appDbContext.SaveChanges();
                }
            })); 
            
        }





    }
}
