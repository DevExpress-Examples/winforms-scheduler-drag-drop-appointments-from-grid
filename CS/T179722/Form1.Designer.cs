namespace T179722
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdTasks = new DevExpress.XtraGrid.GridControl();
            this.gridViewTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSpinDuration = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPriority = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSeverity = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSeverity)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl
            // 
            this.schedulerControl.DataStorage = this.schedulerStorage;
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.Size = new System.Drawing.Size(2200, 898);
            this.schedulerControl.Start = new System.DateTime(2014, 11, 27, 0, 0, 0, 0);
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Text = "schedulerControl1";
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.AppointmentDrag += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.OnSchedulerControlAppointmentDrag);
            this.schedulerControl.AppointmentDrop += new DevExpress.XtraScheduler.AppointmentDragEventHandler(this.OnSchedulerControlAppointmentDrop);
            this.schedulerControl.PrepareDragData += new DevExpress.XtraScheduler.PrepareDragDataEventHandler(this.OnSchedulerControlPrepareDragData);
            this.schedulerControl.AdditionalAppointmentsDrag += new System.EventHandler<DevExpress.XtraScheduler.AdditionalAppointmentsDragEventArgs>(OnSchedulerControlAdditionalAppointmentsDrag);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.schedulerControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdTasks);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(2200, 1346);
            this.splitContainerControl1.SplitterPosition = 898;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdTasks
            // 
            this.grdTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTasks.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grdTasks.Location = new System.Drawing.Point(0, 0);
            this.grdTasks.MainView = this.gridViewTasks;
            this.grdTasks.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grdTasks.Name = "grdTasks";
            this.grdTasks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSpinDuration,
            this.repPriority,
            this.repSeverity});
            this.grdTasks.Size = new System.Drawing.Size(2200, 428);
            this.grdTasks.TabIndex = 0;
            this.grdTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTasks});
            // 
            // gridViewTasks
            // 
            this.gridViewTasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSubject,
            this.colDuration,
            this.colPriority,
            this.colSeverity,
            this.colDescription});
            this.gridViewTasks.DetailHeight = 673;
            this.gridViewTasks.FixedLineWidth = 4;
            this.gridViewTasks.GridControl = this.grdTasks;
            this.gridViewTasks.Name = "gridViewTasks";
            this.gridViewTasks.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridViewTasks.OptionsView.ShowGroupPanel = false;
            this.gridViewTasks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnGridViewTasksMouseDown);
            this.gridViewTasks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnGridViewTasksMouseMove);
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Subject";
            this.colSubject.FieldName = "Subject";
            this.colSubject.MinWidth = 40;
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 0;
            this.colSubject.Width = 320;
            // 
            // colDuration
            // 
            this.colDuration.Caption = "Duration(h)";
            this.colDuration.ColumnEdit = this.repSpinDuration;
            this.colDuration.FieldName = "Duration";
            this.colDuration.MinWidth = 40;
            this.colDuration.Name = "colDuration";
            this.colDuration.Visible = true;
            this.colDuration.VisibleIndex = 1;
            this.colDuration.Width = 458;
            // 
            // repSpinDuration
            // 
            this.repSpinDuration.AutoHeight = false;
            this.repSpinDuration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSpinDuration.Name = "repSpinDuration";
            // 
            // colPriority
            // 
            this.colPriority.Caption = "Priority";
            this.colPriority.ColumnEdit = this.repPriority;
            this.colPriority.FieldName = "Priority";
            this.colPriority.MinWidth = 40;
            this.colPriority.Name = "colPriority";
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 2;
            this.colPriority.Width = 458;
            // 
            // repPriority
            // 
            this.repPriority.AutoHeight = false;
            this.repPriority.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPriority.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Normal", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 2, -1)});
            this.repPriority.Name = "repPriority";
            // 
            // colSeverity
            // 
            this.colSeverity.Caption = "Severity";
            this.colSeverity.ColumnEdit = this.repSeverity;
            this.colSeverity.FieldName = "Severity";
            this.colSeverity.MinWidth = 40;
            this.colSeverity.Name = "colSeverity";
            this.colSeverity.Visible = true;
            this.colSeverity.VisibleIndex = 3;
            this.colSeverity.Width = 458;
            // 
            // repSeverity
            // 
            this.repSeverity.AutoHeight = false;
            this.repSeverity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSeverity.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Minor", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Moderate", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Severe", 2, -1)});
            this.repSeverity.Name = "repSeverity";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 40;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 470;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2200, 1346);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnForm1Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSpinDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSeverity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerStorage;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTasks;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repSpinDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colSeverity;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;

    }
}
