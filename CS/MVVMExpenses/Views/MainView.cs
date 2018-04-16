using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using MVVMExpenses.Models.ViewModels;

namespace MVVMExpenses {
    public partial class MainView : XtraForm {
        public MainView() {
            InitializeComponent();
            this.Opacity = 0;
            if(!DesignMode)
                InitializeNavigation();
            ribbonControl1.Merge += ribbonControl1_Merge;
        }
        void ribbonControl1_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e) {
            ribbonControl1.SelectedPage = e.MergedChild.SelectedPage;
        }
        void InitializeNavigation() {
            var fluentAPI = mvvmContext1.OfType<MyDbContextViewModel>();
            fluentAPI.BindCommand(biAccounts, (x, m) => x.Show(m), x => x.Modules[0]);
            fluentAPI.BindCommand(biCategories, (x, m) => x.Show(m), x => x.Modules[1]);
            fluentAPI.BindCommand(biTransactions, (x, m) => x.Show(m), x => x.Modules[2]);
            //
            fluentAPI.BindCommand(biLogout, x => x.Logout());
            //
            fluentAPI.WithEvent(this, "Load")
                .EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);
            fluentAPI.WithEvent<FormClosingEventArgs>(this, "FormClosing")
                .EventToCommand(x => x.OnClosing(null), new Func<CancelEventArgs, object>((args) => args));
            fluentAPI.SetTrigger(x => x.State, (state) =>
            {
                if(state == AppState.Authorized)
                    Opacity = 1; /*Show Main Form*/
                if(state == AppState.ExitQueued)
                    Close(); // exit the app;
            });
            Messenger.Default.Register<string>(this, OnUserNameMessage);
        }
        void OnUserNameMessage(string userName) {
            if(string.IsNullOrEmpty(userName))
                this.Text = "Expenses Application";
            else
                this.Text = "Expenses Application - (" + userName + ")";
        }
    }
}