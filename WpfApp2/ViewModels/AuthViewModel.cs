using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class AuthViewModel: NotifyPropertyChanged
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private readonly AppDbContext _appDbContext;
        public AuthViewModel(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        private RelayCommand _AuthCommand = null!;
        public RelayCommand AuthCommand
        {
            get => _AuthCommand ?? (_AuthCommand = new RelayCommand((obj) =>
            {
                Login = Login.Trim();
                Password = Password.Trim();
                if(_appDbContext.Users.Any(u => u.Login == Login && u.Password == Password ) )
                {
                    MessageBox.Show("access");
                } else
                {
                    MessageBox.Show("no no time to ravage");
                }
            }));
            }

    }
}
