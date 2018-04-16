Namespace MVVMExpenses.Common.Views
    Partial Public Class LoginView
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
            Me.PasswordTextEdit = New DevExpress.XtraEditors.TextEdit()
            Me.UserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LoginTextEdit = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.ItemForLogin = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForPassword = New DevExpress.XtraLayout.LayoutControlItem()
            Me.MvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DataLayoutControl1.SuspendLayout()
            CType(Me.PasswordTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LoginTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForLogin, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForPassword, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataLayoutControl1
            '
            Me.DataLayoutControl1.Controls.Add(Me.PasswordTextEdit)
            Me.DataLayoutControl1.Controls.Add(Me.LoginTextEdit)
            Me.DataLayoutControl1.DataSource = Me.UserBindingSource
            Me.DataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataLayoutControl1.Location = New System.Drawing.Point(0, 0)
            Me.DataLayoutControl1.Name = "DataLayoutControl1"
            Me.DataLayoutControl1.Root = Me.LayoutControlGroup1
            Me.DataLayoutControl1.Size = New System.Drawing.Size(330, 126)
            Me.DataLayoutControl1.TabIndex = 0
            Me.DataLayoutControl1.Text = "DataLayoutControl1"
            '
            'PasswordTextEdit
            '
            Me.PasswordTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.UserBindingSource, "Password", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.PasswordTextEdit.Location = New System.Drawing.Point(61, 36)
            Me.PasswordTextEdit.Name = "PasswordTextEdit"
            Me.PasswordTextEdit.Size = New System.Drawing.Size(257, 20)
            Me.PasswordTextEdit.StyleController = Me.DataLayoutControl1
            Me.PasswordTextEdit.TabIndex = 5
            '
            'UserBindingSource
            '
            Me.UserBindingSource.DataSource = GetType(MVVMExpenses.DataModels.User)
            '
            'LoginTextEdit
            '
            Me.LoginTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.UserBindingSource, "Login", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.LoginTextEdit.Location = New System.Drawing.Point(61, 12)
            Me.LoginTextEdit.Name = "LoginTextEdit"
            Me.LoginTextEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.LoginTextEdit.Size = New System.Drawing.Size(257, 20)
            Me.LoginTextEdit.StyleController = Me.DataLayoutControl1
            Me.LoginTextEdit.TabIndex = 4
            '
            'LayoutControlGroup1
            '
            Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.LayoutControlGroup1.GroupBordersVisible = False
            Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
            Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
            Me.LayoutControlGroup1.Size = New System.Drawing.Size(330, 126)
            Me.LayoutControlGroup1.TextVisible = False
            '
            'LayoutControlGroup2
            '
            Me.LayoutControlGroup2.AllowDrawBackground = False
            Me.LayoutControlGroup2.GroupBordersVisible = False
            Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForLogin, Me.ItemForPassword})
            Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
            Me.LayoutControlGroup2.Name = "autoGeneratedGroup0"
            Me.LayoutControlGroup2.Size = New System.Drawing.Size(310, 106)
            '
            'ItemForLogin
            '
            Me.ItemForLogin.Control = Me.LoginTextEdit
            Me.ItemForLogin.Location = New System.Drawing.Point(0, 0)
            Me.ItemForLogin.Name = "ItemForLogin"
            Me.ItemForLogin.Size = New System.Drawing.Size(310, 24)
            Me.ItemForLogin.Text = "Login"
            Me.ItemForLogin.TextSize = New System.Drawing.Size(46, 13)
            '
            'ItemForPassword
            '
            Me.ItemForPassword.Control = Me.PasswordTextEdit
            Me.ItemForPassword.Location = New System.Drawing.Point(0, 24)
            Me.ItemForPassword.Name = "ItemForPassword"
            Me.ItemForPassword.Size = New System.Drawing.Size(310, 82)
            Me.ItemForPassword.Text = "Password"
            Me.ItemForPassword.TextSize = New System.Drawing.Size(46, 13)
            '
            'MvvmContext1
            '
            Me.MvvmContext1.ContainerControl = Me
            Me.MvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.LoginViewModel)
            '
            'LoginView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataLayoutControl1)
            Me.Name = "LoginView"
            Me.Size = New System.Drawing.Size(330, 126)
            CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DataLayoutControl1.ResumeLayout(False)
            CType(Me.PasswordTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.UserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LoginTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForLogin, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForPassword, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

        Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
        Friend WithEvents UserBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PasswordTextEdit As DevExpress.XtraEditors.TextEdit
        Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
        Friend WithEvents ItemForLogin As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents ItemForPassword As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents LoginTextEdit As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents MvvmContext1 As DevExpress.Utils.MVVM.MVVMContext

    End Class
End Namespace

