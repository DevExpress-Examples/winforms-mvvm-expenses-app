using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MVVMExpenses.ViewModels;

namespace MVVMExpenses.Views {
    public partial class LoginView : DevExpress.XtraEditors.XtraUserControl {
        public LoginView() {
            InitializeComponent();
            PasswordTextEdit.Properties.PasswordChar = '*';
        }

        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            var fluentAPI = mvvmContext1.OfType<LoginViewModel>();
            fluentAPI.SetObjectDataSourceBinding(userBindingSource,
                x => x.CurrentUser, x => x.Update());
            

            foreach(string item in mvvmContext1.GetViewModel<LoginViewModel>().LookUpUsers) 
                LoginTextEdit.Properties.Items.Add(item);
            fluentAPI.ViewModel.Init();
        }
    }
}
