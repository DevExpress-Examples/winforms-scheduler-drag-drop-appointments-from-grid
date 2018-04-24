Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo


Namespace T179722
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            schedulerControl.Start = Date.Now
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            schedulerControl.GroupType = SchedulerGroupType.Resource
            schedulerStorage.Appointments.ResourceSharing = True

            DataHelper.FillResources(schedulerStorage, 5)
            grdTasks.DataSource = DataHelper.GenerateScheduleTasks()
        End Sub

        #Region "#GetGridHitInfo"
        Private downHitInfo As GridHitInfo

        Private Sub gridViewTasks_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridViewTasks.MouseDown
            Dim view As GridView = TryCast(sender, GridView)
            downHitInfo = Nothing

            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            If Control.ModifierKeys <> Keys.None Then
                Return
            End If
            If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
                downHitInfo = hitInfo
            End If
        End Sub
        #End Region ' #GetGridHitInfo

        #Region "#GridViewMouseMove"
        Private Sub gridViewTasks_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridViewTasks.MouseMove
            Dim view As GridView = TryCast(sender, GridView)
            If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
                Dim dragSize As Size = SystemInformation.DragSize
                Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)

                If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                    downHitInfo = Nothing
                End If
            End If
        End Sub
        #End Region ' #GridViewMouseMove

        #Region "#GetDragData"
        Private Function GetDragData(ByVal view As GridView) As SchedulerDragData
            Dim selection() As Integer = view.GetSelectedRows()
            If selection Is Nothing Then
                Return Nothing
            End If

            Dim appointments As New AppointmentBaseCollection()
            Dim count As Integer = selection.Length
            For i As Integer = 0 To count - 1
                Dim rowIndex As Integer = selection(i)
                Dim apt As Appointment = schedulerStorage.CreateAppointment(AppointmentType.Normal)
                apt.Subject = CStr(view.GetRowCellValue(rowIndex, "Subject"))
                apt.LabelKey = CInt((view.GetRowCellValue(rowIndex, "Severity")))
                apt.StatusKey = CInt((view.GetRowCellValue(rowIndex, "Priority")))
                apt.Start = Date.Now
                apt.Duration = TimeSpan.FromHours(CInt((view.GetRowCellValue(rowIndex, "Duration"))))
                apt.Description = CStr(view.GetRowCellValue(rowIndex, "Description"))
                appointments.Add(apt)
            Next i

            Return New SchedulerDragData(appointments, 0)
        End Function
        #End Region ' #GetDragData

        #Region "#SchedulerControlAppointmentDrop"
        Private Sub schedulerControl_AppointmentDrop(ByVal sender As Object, ByVal e As AppointmentDragEventArgs) Handles schedulerControl.AppointmentDrop
            Dim createEventMsg As String = "Creating an event at {0} on {1}."
            Dim moveEventMsg As String = "Moving the event from {0} on {1} to {2} on {3}."

            Dim srcStart As Date = e.SourceAppointment.Start
            Dim newStart As Date = e.EditedAppointment.Start

            Dim msg As String = If(srcStart = Date.MinValue, String.Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()), String.Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString()))

            If XtraMessageBox.Show(msg & ControlChars.CrLf & "Proceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Allow = False
            End If
        End Sub
        #End Region ' #SchedulerControlAppointmentDrop
    End Class
End Namespace