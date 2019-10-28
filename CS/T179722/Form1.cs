using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;

namespace T179722 {
    public partial class Form1 : XtraForm {

        public Form1() {
            InitializeComponent();
            this.schedulerControl.Start = DateTime.Now;
        }

        GridHitInfo DownHitInfo { get; set; }

        void OnForm1Load(object sender, EventArgs e) {
            this.schedulerControl.GroupType = SchedulerGroupType.Resource;
            this.schedulerStorage.Appointments.ResourceSharing = true;

            DataHelper.FillResources(this.schedulerStorage, 5);
            this.grdTasks.DataSource = DataHelper.GenerateScheduleTasks();
        }

        void OnGridViewTasksMouseDown(object sender, MouseEventArgs e) {
            GridView view = sender as GridView;
            this.DownHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                this.DownHitInfo = hitInfo;
        }

        void OnGridViewTasksMouseMove(object sender, MouseEventArgs e) {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && this.DownHitInfo != null) {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(this.DownHitInfo.HitPoint.X - dragSize.Width / 2,
                    this.DownHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y))) {
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                    this.DownHitInfo = null;
                }
            }
        }

        void OnSchedulerControlAppointmentDrop(object sender, AppointmentDragEventArgs e) {
            string createEventMsg = "Creating an event at {0} on {1}.";
            string moveEventMsg = "Moving the event from {0} on {1} to {2} on {3}.";

            DateTime srcStart = e.SourceAppointment.Start;
            DateTime newStart = e.EditedAppointment.Start;

            string msg = (srcStart == DateTime.MinValue) ? String.Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()) :
                String.Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString());

            if (XtraMessageBox.Show(msg + "\r\nProceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                e.Allow = false;
            }
        }

        void OnSchedulerControlAppointmentDrag(object sender, AppointmentDragEventArgs e) {
            Appointment apt = e.EditedAppointment;
            if (apt.Start == DateTime.MinValue)
                apt.Start = e.HitInterval.Start;
        }

        void OnSchedulerControlAdditionalAppointmentsDrag(object sender, AdditionalAppointmentsDragEventArgs e) {
            List<AppointmentExchangeData> exchangeList = new List<AppointmentExchangeData>();
            foreach (AppointmentDragInfo aptInfo in e.PrimaryAppointmentInfos) {
                var apt = aptInfo.EditedAppointment;
                exchangeList.Add(new AppointmentExchangeData() {
                    Subject = apt.Subject,
                    Description = apt.Description,
                    Start = DateTime.MinValue,
                    Duration = apt.Duration,
                    LabelKey = (int)apt.LabelKey,
                    StatusKey = (int)apt.StatusKey
                });
            }
            e.Data.SetData(DataFormats.Serializable, exchangeList);
        }

        void OnSchedulerControlPrepareDragData(object sender, PrepareDragDataEventArgs e) {
            object data = e.DataObject.GetData(DataFormats.Serializable);
            AppointmentBaseCollection appointments = new AppointmentBaseCollection();
            foreach (AppointmentExchangeData item in (IList)data) {
                var apt = this.schedulerStorage.CreateAppointment(AppointmentType.Normal);
                apt.Subject = item.Subject;
                apt.Description = item.Description;
                apt.Start = item.Start;
                apt.Duration = item.Duration;
                apt.LabelKey = item.LabelKey;
                apt.StatusKey = item.StatusKey;
                appointments.Add(apt);
            }
            SchedulerDragData schedulerDragData = new SchedulerDragData(appointments);
            e.DragData = schedulerDragData;
        }

        IDataObject GetDragData(GridView view) {
            int[] selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            List<AppointmentExchangeData> exchangeList = new List<AppointmentExchangeData>();
            int count = selection.Length;
            for (int i = 0; i < count; i++) {
                int rowIndex = selection[i];
                exchangeList.Add(new AppointmentExchangeData() {
                    Subject = (string)view.GetRowCellValue(rowIndex, "Subject"),
                    LabelKey = (int)view.GetRowCellValue(rowIndex, "Severity"),
                    StatusKey = (int)view.GetRowCellValue(rowIndex, "Priority"),
                    Start = DateTime.MinValue,
                    Duration = TimeSpan.FromHours((int)view.GetRowCellValue(rowIndex, "Duration")),
                    Description = (string)view.GetRowCellValue(rowIndex, "Description"),
                });
            }

            return new DataObject(DataFormats.Serializable, exchangeList);
        }
    }
}