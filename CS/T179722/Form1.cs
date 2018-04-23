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


namespace T179722
{
    public partial class Form1 : XtraForm
    {       
        public Form1()
        {
            InitializeComponent();
            schedulerControl.Start = System.DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            schedulerControl.GroupType = SchedulerGroupType.Resource;
            schedulerStorage.Appointments.ResourceSharing = true;

            DataHelper.FillResources(schedulerStorage, 5);
            grdTasks.DataSource = DataHelper.GenerateScheduleTasks();
        }       
        
        #region #GetGridHitInfo
        GridHitInfo downHitInfo;

        private void gridViewTasks_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                downHitInfo = hitInfo;
        }
        #endregion #GetGridHitInfo

        #region #GridViewMouseMove
        private void gridViewTasks_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }
        #endregion #GridViewMouseMove

        #region #GetDragData
        SchedulerDragData GetDragData(GridView view)
        {
            int[] selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            AppointmentBaseCollection appointments = new AppointmentBaseCollection();
            int count = selection.Length;
            for (int i = 0; i < count; i++)
            {
                int rowIndex = selection[i];
                Appointment apt = schedulerStorage.CreateAppointment(AppointmentType.Normal);
                apt.Subject = (string)view.GetRowCellValue(rowIndex, "Subject");
                apt.LabelId = (int)view.GetRowCellValue(rowIndex, "Severity");
                apt.StatusId = (int)view.GetRowCellValue(rowIndex, "Priority");
                apt.Start = DateTime.Now;
                apt.Duration = TimeSpan.FromHours((int)view.GetRowCellValue(rowIndex, "Duration"));
                apt.Description = (string)view.GetRowCellValue(rowIndex, "Description");
                appointments.Add(apt);
            }

            return new SchedulerDragData(appointments, 0);
        }
        #endregion #GetDragData

        #region #SchedulerControlAppointmentDrop
        private void schedulerControl_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
            string createEventMsg = "Creating an event at {0} on {1}.";
            string moveEventMsg = "Moving the event from {0} on {1} to {2} on {3}.";

            DateTime srcStart = e.SourceAppointment.Start;
            DateTime newStart = e.EditedAppointment.Start;

            string msg = (srcStart == DateTime.MinValue) ? String.Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()) :
                String.Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString());

            if (XtraMessageBox.Show(msg + "\r\nProceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Allow = false;
                e.Handled = true;
            }
        }
        #endregion #SchedulerControlAppointmentDrop
    }
}