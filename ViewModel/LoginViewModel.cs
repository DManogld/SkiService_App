using SkiService_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiService_App.ViewModel
{
    
    public class LoginViewModel
    {
        LoginView lw = new LoginView();

        public void Open()
        {
            lw.Show();
        }
        public void Close()
        {
            lw.Close();
        }

    }
}
