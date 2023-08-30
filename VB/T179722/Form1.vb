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
Imports System.Collections

Namespace T179722

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            Me.InitializeComponent()
            Me.schedulerControl.Start = System.DateTime.Now
        End Sub

        Private Property DownHitInfo As GridHitInfo

        Private Sub OnForm1Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.schedulerControl.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerStorage.Appointments.ResourceSharing = True
            T179722.DataHelper.FillResources(Me.schedulerStorage, 5)
            Me.grdTasks.DataSource = T179722.DataHelper.GenerateScheduleTasks()
        End Sub

        Private Sub OnGridViewTasksMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Me.DownHitInfo = Nothing
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))
            If System.Windows.Forms.Control.ModifierKeys <> System.Windows.Forms.Keys.None Then Return
            If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then Me.DownHitInfo = hitInfo
        End Sub

        Private Sub OnGridViewTasksMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso Me.DownHitInfo IsNot Nothing Then
                Dim dragSize As System.Drawing.Size = System.Windows.Forms.SystemInformation.DragSize
                Dim dragRect As System.Drawing.Rectangle = New System.Drawing.Rectangle(New System.Drawing.Point(Me.DownHitInfo.HitPoint.X - dragSize.Width \ 2, Me.DownHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
                If Not dragRect.Contains(New System.Drawing.Point(e.X, e.Y)) Then
                    view.GridControl.DoDragDrop(Me.GetDragData(view), System.Windows.Forms.DragDropEffects.All)
                    Me.DownHitInfo = Nothing
                End If
            End If
        End Sub

        Private Sub OnSchedulerControlAppointmentDrop(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentDragEventArgs)
            Dim createEventMsg As String = "Creating an event at {0} on {1}."
            Dim moveEventMsg As String = "Moving the event from {0} on {1} to {2} on {3}."
            Dim srcStart As System.DateTime = e.SourceAppointment.Start
            Dim newStart As System.DateTime = e.EditedAppointment.Start
            Dim msg As String = If((srcStart = System.DateTime.MinValue), System.[String].Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()), System.[String].Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString()))
            If DevExpress.XtraEditors.XtraMessageBox.Show(msg & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Proceed?", System.Windows.Forms.Application.ProductName, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                e.Allow = False
            End If
        End Sub

        Private Sub OnSchedulerControlAppointmentDrag(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentDragEventArgs)
            Dim apt As DevExpress.XtraScheduler.Appointment = e.EditedAppointment
            If apt.Start = System.DateTime.MinValue Then apt.Start = e.HitInterval.Start
        End Sub

        Private Sub OnSchedulerControlAdditionalAppointmentsDrag(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AdditionalAppointmentsDragEventArgs)
            Dim exchangeList As System.Collections.Generic.List(Of T179722.AppointmentExchangeData) = New System.Collections.Generic.List(Of T179722.AppointmentExchangeData)()
            For Each aptInfo As DevExpress.XtraScheduler.AppointmentDragInfo In e.PrimaryAppointmentInfos
                Dim apt = aptInfo.EditedAppointment
                exchangeList.Add(New T179722.AppointmentExchangeData() With {.Subject = apt.Subject, .Description = apt.Description, .Start = System.DateTime.MinValue, .Duration = apt.Duration, .LabelKey = CInt(apt.LabelKey), .StatusKey = CInt(apt.StatusKey)})
            Next

            e.Data.SetData(System.Windows.Forms.DataFormats.Serializable, exchangeList)
        End Sub

        Private Sub OnSchedulerControlPrepareDragData(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.PrepareDragDataEventArgs)
            Dim data As Object = e.DataObject.GetData(System.Windows.Forms.DataFormats.Serializable)
            Dim appointments As DevExpress.XtraScheduler.AppointmentBaseCollection = New DevExpress.XtraScheduler.AppointmentBaseCollection()
            For Each item As T179722.AppointmentExchangeData In CType(data, System.Collections.IList)
                Dim apt = Me.schedulerStorage.CreateAppointment(DevExpress.XtraScheduler.AppointmentType.Normal)
                apt.Subject = item.Subject
                apt.Description = item.Description
                apt.Start = item.Start
                apt.Duration = item.Duration
                apt.LabelKey = item.LabelKey
                apt.StatusKey = item.StatusKey
                appointments.Add(apt)
            Next

            Dim schedulerDragData As DevExpress.XtraScheduler.SchedulerDragData = New DevExpress.XtraScheduler.SchedulerDragData(appointments)
            e.DragData = schedulerDragData
        End Sub

        Private Function GetDragData(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView) As IDataObject
            Dim selection As Integer() = view.GetSelectedRows()
            If selection Is Nothing Then Return Nothing
            Dim exchangeList As System.Collections.Generic.List(Of T179722.AppointmentExchangeData) = New System.Collections.Generic.List(Of T179722.AppointmentExchangeData)()
            Dim count As Integer = selection.Length
            For i As Integer = 0 To count - 1
                Dim rowIndex As Integer = selection(i)
                exchangeList.Add(New T179722.AppointmentExchangeData() With {.Subject = CStr(view.GetRowCellValue(rowIndex, "Subject")), .LabelKey = CInt(view.GetRowCellValue(rowIndex, "Severity")), .StatusKey = CInt(view.GetRowCellValue(rowIndex, "Priority")), .Start = System.DateTime.MinValue, .Duration = System.TimeSpan.FromHours(CInt(view.GetRowCellValue(rowIndex, "Duration"))), .Description = CStr(view.GetRowCellValue(rowIndex, "Description"))})
            Next

            Return New System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.Serializable, exchangeList)
        End Function
    End Class
End Namespace
