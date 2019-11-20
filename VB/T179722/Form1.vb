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
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			Me.schedulerControl.Start = Date.Now
		End Sub

		Private Property DownHitInfo() As GridHitInfo

		Private Sub OnForm1Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Me.schedulerControl.GroupType = SchedulerGroupType.Resource
			Me.schedulerStorage.Appointments.ResourceSharing = True

			DataHelper.FillResources(Me.schedulerStorage, 5)
			Me.grdTasks.DataSource = DataHelper.GenerateScheduleTasks()
		End Sub

		Private Sub OnGridViewTasksMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridViewTasks.MouseDown
			Dim view As GridView = TryCast(sender, GridView)
			Me.DownHitInfo = Nothing

			Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
			If Control.ModifierKeys <> Keys.None Then
				Return
			End If
			If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
				Me.DownHitInfo = hitInfo
			End If
		End Sub

		Private Sub OnGridViewTasksMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles gridViewTasks.MouseMove
			Dim view As GridView = TryCast(sender, GridView)
			If e.Button = MouseButtons.Left AndAlso Me.DownHitInfo IsNot Nothing Then
				Dim dragSize As Size = SystemInformation.DragSize
				Dim dragRect As New Rectangle(New Point(Me.DownHitInfo.HitPoint.X - dragSize.Width \ 2, Me.DownHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)

				If Not dragRect.Contains(New Point(e.X, e.Y)) Then
					view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
					Me.DownHitInfo = Nothing
				End If
			End If
		End Sub

		Private Sub OnSchedulerControlAppointmentDrop(ByVal sender As Object, ByVal e As AppointmentDragEventArgs) Handles schedulerControl.AppointmentDrop
			Dim createEventMsg As String = "Creating an event at {0} on {1}."
			Dim moveEventMsg As String = "Moving the event from {0} on {1} to {2} on {3}."

			Dim srcStart As Date = e.SourceAppointment.Start
			Dim newStart As Date = e.EditedAppointment.Start

			Dim msg As String = If(srcStart = Date.MinValue, String.Format(createEventMsg, newStart.ToShortTimeString(), newStart.ToShortDateString()), String.Format(moveEventMsg, srcStart.ToShortTimeString(), srcStart.ToShortDateString(), newStart.ToShortTimeString(), newStart.ToShortDateString()))

			If XtraMessageBox.Show(msg & vbCrLf & "Proceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
				e.Allow = False
			End If
		End Sub

		Private Sub OnSchedulerControlAppointmentDrag(ByVal sender As Object, ByVal e As AppointmentDragEventArgs) Handles schedulerControl.AppointmentDrag
			Dim apt As Appointment = e.EditedAppointment
			If apt.Start = Date.MinValue Then
				apt.Start = e.HitInterval.Start
			End If
		End Sub

		Private Sub OnSchedulerControlAdditionalAppointmentsDrag(ByVal sender As Object, ByVal e As AdditionalAppointmentsDragEventArgs) Handles schedulerControl.AdditionalAppointmentsDrag
			Dim exchangeList As New List(Of AppointmentExchangeData)()
			For Each aptInfo As AppointmentDragInfo In e.PrimaryAppointmentInfos
				Dim apt = aptInfo.EditedAppointment
				exchangeList.Add(New AppointmentExchangeData() With {
					.Subject = apt.Subject,
					.Description = apt.Description,
					.Start = Date.MinValue,
					.Duration = apt.Duration,
					.LabelKey = CInt(Math.Truncate(apt.LabelKey)),
					.StatusKey = CInt(Math.Truncate(apt.StatusKey))
				})
			Next aptInfo
			e.Data.SetData(DataFormats.Serializable, exchangeList)
		End Sub

		Private Sub OnSchedulerControlPrepareDragData(ByVal sender As Object, ByVal e As PrepareDragDataEventArgs) Handles schedulerControl.PrepareDragData
			Dim data As Object = e.DataObject.GetData(DataFormats.Serializable)
			Dim appointments As New AppointmentBaseCollection()
			For Each item As AppointmentExchangeData In DirectCast(data, IList)
				Dim apt = Me.schedulerStorage.CreateAppointment(AppointmentType.Normal)
				apt.Subject = item.Subject
				apt.Description = item.Description
				apt.Start = item.Start
				apt.Duration = item.Duration
				apt.LabelKey = item.LabelKey
				apt.StatusKey = item.StatusKey
				appointments.Add(apt)
			Next item
			Dim schedulerDragData As New SchedulerDragData(appointments)
			e.DragData = schedulerDragData
		End Sub

		Private Function GetDragData(ByVal view As GridView) As IDataObject
			Dim selection() As Integer = view.GetSelectedRows()
			If selection Is Nothing Then
				Return Nothing
			End If

			Dim exchangeList As New List(Of AppointmentExchangeData)()
			Dim count As Integer = selection.Length
			For i As Integer = 0 To count - 1
				Dim rowIndex As Integer = selection(i)
				exchangeList.Add(New AppointmentExchangeData() With {
					.Subject = CStr(view.GetRowCellValue(rowIndex, "Subject")),
					.LabelKey = CInt(Math.Truncate(view.GetRowCellValue(rowIndex, "Severity"))),
					.StatusKey = CInt(Math.Truncate(view.GetRowCellValue(rowIndex, "Priority"))),
					.Start = Date.MinValue,
					.Duration = TimeSpan.FromHours(CInt(Math.Truncate(view.GetRowCellValue(rowIndex, "Duration")))),
					.Description = CStr(view.GetRowCellValue(rowIndex, "Description"))
				})
			Next i

			Return New DataObject(DataFormats.Serializable, exchangeList)
		End Function
	End Class
End Namespace