<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToolbox
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Standard", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Mouse", "input-mouse.png")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Point (Vertex)", "list-add.png.ico")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Polygon", "list-add.png.ico")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToolbox))
        Me.lvwTools = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuEditor = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuItemNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuItemQuit = New System.Windows.Forms.ToolStripMenuItem
        Me.backWorker = New System.ComponentModel.BackgroundWorker
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwTools
        '
        Me.lvwTools.BackColor = System.Drawing.SystemColors.Control
        Me.lvwTools.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwTools.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvwTools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwTools.FullRowSelect = True
        ListViewGroup2.Header = "Standard"
        ListViewGroup2.Name = "ListViewGroup1"
        Me.lvwTools.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup2})
        Me.lvwTools.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        ListViewItem4.Group = ListViewGroup2
        ListViewItem5.Group = ListViewGroup2
        ListViewItem6.Group = ListViewGroup2
        Me.lvwTools.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4, ListViewItem5, ListViewItem6})
        Me.lvwTools.Location = New System.Drawing.Point(0, 24)
        Me.lvwTools.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvwTools.MultiSelect = False
        Me.lvwTools.Name = "lvwTools"
        Me.lvwTools.Size = New System.Drawing.Size(196, 546)
        Me.lvwTools.SmallImageList = Me.ImageList1
        Me.lvwTools.TabIndex = 0
        Me.lvwTools.UseCompatibleStateImageBehavior = False
        Me.lvwTools.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Controlname"
        Me.ColumnHeader1.Width = 150
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "list-add.png.ico")
        Me.ImageList1.Images.SetKeyName(1, "input-mouse.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditor})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(196, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuEditor
        '
        Me.mnuEditor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemNew, Me.mnuItemQuit})
        Me.mnuEditor.Name = "mnuEditor"
        Me.mnuEditor.Size = New System.Drawing.Size(50, 20)
        Me.mnuEditor.Text = "&Editor"
        '
        'mnuItemNew
        '
        Me.mnuItemNew.Name = "mnuItemNew"
        Me.mnuItemNew.Size = New System.Drawing.Size(98, 22)
        Me.mnuItemNew.Text = "&New"
        '
        'mnuItemQuit
        '
        Me.mnuItemQuit.Name = "mnuItemQuit"
        Me.mnuItemQuit.Size = New System.Drawing.Size(152, 22)
        Me.mnuItemQuit.Text = "&Quit"
        '
        'backWorker
        '
        '
        'frmToolbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 570)
        Me.Controls.Add(Me.lvwTools)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmToolbox"
        Me.Text = "Map-Editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwTools As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuEditor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItemQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents backWorker As System.ComponentModel.BackgroundWorker
End Class
