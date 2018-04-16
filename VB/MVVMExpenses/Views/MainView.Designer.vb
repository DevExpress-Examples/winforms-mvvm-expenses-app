Namespace MVVMExpenses
    Partial Public Class MainView
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

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainView))
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            Me.tabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.biAccounts = New DevExpress.XtraBars.BarButtonItem()
            Me.biCategories = New DevExpress.XtraBars.BarButtonItem()
            Me.biTransactions = New DevExpress.XtraBars.BarButtonItem()
            Me.biLogout = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.documentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'defaultLookAndFeel1
            '
            Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray"
            '
            'mvvmContext1
            '
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.RegistrationExpressions.AddRange(New DevExpress.Utils.MVVM.RegistrationExpression() {DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(Nothing, False, Me.tabbedView1)})
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.MyDbContextViewModel)
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.biAccounts, Me.biCategories, Me.biTransactions, Me.biLogout})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 2
            Me.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(799, 140)
            '
            'biAccounts
            '
            Me.biAccounts.Caption = "Accounts"
            Me.biAccounts.Glyph = CType(resources.GetObject("biAccounts.Glyph"), System.Drawing.Image)
            Me.biAccounts.Id = 1
            Me.biAccounts.LargeGlyph = CType(resources.GetObject("biAccounts.LargeGlyph"), System.Drawing.Image)
            Me.biAccounts.Name = "biAccounts"
            '
            'biCategories
            '
            Me.biCategories.Caption = "Categories"
            Me.biCategories.Glyph = CType(resources.GetObject("biCategories.Glyph"), System.Drawing.Image)
            Me.biCategories.Id = 2
            Me.biCategories.LargeGlyph = CType(resources.GetObject("biCategories.LargeGlyph"), System.Drawing.Image)
            Me.biCategories.Name = "biCategories"
            '
            'biTransactions
            '
            Me.biTransactions.Caption = "Transactions"
            Me.biTransactions.Glyph = CType(resources.GetObject("biTransactions.Glyph"), System.Drawing.Image)
            Me.biTransactions.Id = 3
            Me.biTransactions.LargeGlyph = CType(resources.GetObject("biTransactions.LargeGlyph"), System.Drawing.Image)
            Me.biTransactions.Name = "biTransactions"
            '
            'biLogout
            '
            Me.biLogout.Caption = "Logout"
            Me.biLogout.Glyph = CType(resources.GetObject("biLogout.Glyph"), System.Drawing.Image)
            Me.biLogout.Id = 1
            Me.biLogout.LargeGlyph = CType(resources.GetObject("biLogout.LargeGlyph"), System.Drawing.Image)
            Me.biLogout.Name = "biLogout"
            '
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Pages"
            '
            'ribbonPageGroup1
            '
            Me.ribbonPageGroup1.ItemLinks.Add(Me.biAccounts)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.biCategories)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.biTransactions)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.biLogout)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Navigation"
            '
            'documentManager1
            '
            Me.documentManager1.ContainerControl = Me
            Me.documentManager1.MenuManager = Me.ribbonControl1
            Me.documentManager1.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always
            Me.documentManager1.View = Me.tabbedView1
            Me.documentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.tabbedView1})
            '
            'MainView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(799, 430)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MainView"
            Me.Text = "Expenses Application"
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.documentManager1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private documentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
        Private tabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
        Private biAccounts As DevExpress.XtraBars.BarButtonItem
        Private biCategories As DevExpress.XtraBars.BarButtonItem
        Private biTransactions As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents biLogout As DevExpress.XtraBars.BarButtonItem

    End Class
End Namespace

