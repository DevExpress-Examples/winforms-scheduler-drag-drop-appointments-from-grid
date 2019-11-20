Namespace T179722
	Partial Public Class Form1
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
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl = New DevExpress.XtraScheduler.SchedulerControl()
			Me.schedulerStorage = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
			Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
			Me.grdTasks = New DevExpress.XtraGrid.GridControl()
			Me.gridViewTasks = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colSubject = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colDuration = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repSpinDuration = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
			Me.colPriority = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repPriority = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
			Me.colSeverity = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repSeverity = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
			Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainerControl1.SuspendLayout()
			CType(Me.grdTasks, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridViewTasks, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repSpinDuration, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repPriority, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repSeverity, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' schedulerControl
			' 
			Me.schedulerControl.DataStorage = Me.schedulerStorage
			Me.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.schedulerControl.Location = New System.Drawing.Point(0, 0)
			Me.schedulerControl.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.schedulerControl.Name = "schedulerControl"
			Me.schedulerControl.Size = New System.Drawing.Size(2200, 898)
			Me.schedulerControl.Start = New Date(2014, 11, 27, 0, 0, 0, 0)
			Me.schedulerControl.TabIndex = 0
			Me.schedulerControl.Text = "schedulerControl1"
			Me.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1)
			Me.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.schedulerControl.AppointmentDrag += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.OnSchedulerControlAppointmentDrag);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.schedulerControl.AppointmentDrop += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.OnSchedulerControlAppointmentDrop);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.schedulerControl.PrepareDragData += new DevExpress.XtraScheduler.PrepareDragDataEventHandler(this.OnSchedulerControlPrepareDragData);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.schedulerControl.AdditionalAppointmentsDrag += new System.EventHandler<DevExpress.XtraScheduler.AdditionalAppointmentsDragEventArgs>(OnSchedulerControlAdditionalAppointmentsDrag);
			' 
			' splitContainerControl1
			' 
			Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainerControl1.Horizontal = False
			Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
			Me.splitContainerControl1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.splitContainerControl1.Name = "splitContainerControl1"
			Me.splitContainerControl1.Panel1.Controls.Add(Me.schedulerControl)
			Me.splitContainerControl1.Panel1.Text = "Panel1"
			Me.splitContainerControl1.Panel2.Controls.Add(Me.grdTasks)
			Me.splitContainerControl1.Panel2.Text = "Panel2"
			Me.splitContainerControl1.Size = New System.Drawing.Size(2200, 1346)
			Me.splitContainerControl1.SplitterPosition = 898
			Me.splitContainerControl1.TabIndex = 1
			Me.splitContainerControl1.Text = "splitContainerControl1"
			' 
			' grdTasks
			' 
			Me.grdTasks.Cursor = System.Windows.Forms.Cursors.Default
			Me.grdTasks.Dock = System.Windows.Forms.DockStyle.Fill
			Me.grdTasks.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.grdTasks.Location = New System.Drawing.Point(0, 0)
			Me.grdTasks.MainView = Me.gridViewTasks
			Me.grdTasks.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.grdTasks.Name = "grdTasks"
			Me.grdTasks.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repSpinDuration, Me.repPriority, Me.repSeverity})
			Me.grdTasks.Size = New System.Drawing.Size(2200, 428)
			Me.grdTasks.TabIndex = 0
			Me.grdTasks.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridViewTasks})
			' 
			' gridViewTasks
			' 
			Me.gridViewTasks.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colSubject, Me.colDuration, Me.colPriority, Me.colSeverity, Me.colDescription})
			Me.gridViewTasks.DetailHeight = 673
			Me.gridViewTasks.FixedLineWidth = 4
			Me.gridViewTasks.GridControl = Me.grdTasks
			Me.gridViewTasks.Name = "gridViewTasks"
			Me.gridViewTasks.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
			Me.gridViewTasks.OptionsView.ShowGroupPanel = False
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.gridViewTasks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnGridViewTasksMouseDown);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.gridViewTasks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnGridViewTasksMouseMove);
			' 
			' colSubject
			' 
			Me.colSubject.Caption = "Subject"
			Me.colSubject.FieldName = "Subject"
			Me.colSubject.MinWidth = 40
			Me.colSubject.Name = "colSubject"
			Me.colSubject.Visible = True
			Me.colSubject.VisibleIndex = 0
			Me.colSubject.Width = 320
			' 
			' colDuration
			' 
			Me.colDuration.Caption = "Duration(h)"
			Me.colDuration.ColumnEdit = Me.repSpinDuration
			Me.colDuration.FieldName = "Duration"
			Me.colDuration.MinWidth = 40
			Me.colDuration.Name = "colDuration"
			Me.colDuration.Visible = True
			Me.colDuration.VisibleIndex = 1
			Me.colDuration.Width = 458
			' 
			' repSpinDuration
			' 
			Me.repSpinDuration.AutoHeight = False
			Me.repSpinDuration.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repSpinDuration.Name = "repSpinDuration"
			' 
			' colPriority
			' 
			Me.colPriority.Caption = "Priority"
			Me.colPriority.ColumnEdit = Me.repPriority
			Me.colPriority.FieldName = "Priority"
			Me.colPriority.MinWidth = 40
			Me.colPriority.Name = "colPriority"
			Me.colPriority.Visible = True
			Me.colPriority.VisibleIndex = 2
			Me.colPriority.Width = 458
			' 
			' repPriority
			' 
			Me.repPriority.AutoHeight = False
			Me.repPriority.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repPriority.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 0, -1),
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Normal", 1, -1),
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 2, -1)
			})
			Me.repPriority.Name = "repPriority"
			' 
			' colSeverity
			' 
			Me.colSeverity.Caption = "Severity"
			Me.colSeverity.ColumnEdit = Me.repSeverity
			Me.colSeverity.FieldName = "Severity"
			Me.colSeverity.MinWidth = 40
			Me.colSeverity.Name = "colSeverity"
			Me.colSeverity.Visible = True
			Me.colSeverity.VisibleIndex = 3
			Me.colSeverity.Width = 458
			' 
			' repSeverity
			' 
			Me.repSeverity.AutoHeight = False
			Me.repSeverity.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repSeverity.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Minor", 0, -1),
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Moderate", 1, -1),
				New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Severe", 2, -1)
			})
			Me.repSeverity.Name = "repSeverity"
			' 
			' colDescription
			' 
			Me.colDescription.Caption = "Description"
			Me.colDescription.FieldName = "Description"
			Me.colDescription.MinWidth = 40
			Me.colDescription.Name = "colDescription"
			Me.colDescription.Visible = True
			Me.colDescription.VisibleIndex = 4
			Me.colDescription.Width = 470
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(12F, 25F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(2200, 1346)
			Me.Controls.Add(Me.splitContainerControl1)
			Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.OnForm1Load);
			CType(Me.schedulerControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.schedulerStorage, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.splitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainerControl1.ResumeLayout(False)
			CType(Me.grdTasks, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridViewTasks, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repSpinDuration, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repPriority, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repSeverity, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents schedulerControl As DevExpress.XtraScheduler.SchedulerControl
		Private schedulerStorage As DevExpress.XtraScheduler.SchedulerDataStorage
		Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
		Private grdTasks As DevExpress.XtraGrid.GridControl
		Private WithEvents gridViewTasks As DevExpress.XtraGrid.Views.Grid.GridView
		Private colSubject As DevExpress.XtraGrid.Columns.GridColumn
		Private colDuration As DevExpress.XtraGrid.Columns.GridColumn
		Private repSpinDuration As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
		Private colPriority As DevExpress.XtraGrid.Columns.GridColumn
		Private repPriority As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
		Private colSeverity As DevExpress.XtraGrid.Columns.GridColumn
		Private repSeverity As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
		Private colDescription As DevExpress.XtraGrid.Columns.GridColumn

	End Class
End Namespace
