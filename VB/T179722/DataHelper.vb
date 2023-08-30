Imports System
Imports System.Data
Imports DevExpress.XtraScheduler

Namespace T179722

    Public MustInherit Class DataHelper

        Public Shared RandomInstance As Random = New Random()

        Public Shared Users As String() = New String() {"Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett", "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee"}

        Private Shared taskDescriptions As String() = New String() {"Implementing DevExpress MasterView control into Accounting System.", "Web Edition: Data Entry Page. The issue with date validation.", "Payables Due Calculator. It is ready for testing.", "Web Edition: Search Page. It is ready for testing.", "Main Menu: Duplicate Items. Somebody has to review all menu items in the system.", "Receivables Calculator. Where can I found the complete specs", "Ledger: Inconsistency. Please fix it.", "Receivables Printing. It is ready for testing.", "Screen Redraw. Somebody has to look at it.", "Email System. What library we are going to use?", "Adding New Vendors Fails. This module doesn't work completely!", "History. Will we track the sales history in our system?", "Main Menu: Add a File menu. File menu is missed!!!", "Currency Mask. The current currency mask in completely inconvinience.", "Drag & Drop. In the schedule module drag & drop is not available.", "Data Import. What competitors databases will we support?", "Reports. The list of incomplete reports.", "Data Archiving. This features is still missed in our application", "Email Attachments. How to add the multiple attachment? I did not find a way to do it.", "Check Register. We are using different paths for different modules.", "Data Export. Our customers asked for export into Excel"}

        Public Shared Sub FillResources(ByVal storage As SchedulerDataStorage, ByVal count As Integer)
            Dim resources As ResourceCollection = storage.Resources.Items
            Dim cnt As Integer = Math.Min(count, Users.Length)
            For i As Integer = 1 To cnt
                Dim resource As Resource = storage.CreateResource(i)
                resource.Caption = Users(i - 1)
                resources.Add(resource)
            Next
        End Sub

        Public Shared Function GenerateScheduleTasks() As DataTable
            Dim tbl As DataTable = New DataTable()
            tbl = New DataTable("ScheduleTasks")
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("Subject", GetType(String))
            tbl.Columns.Add("Severity", GetType(Integer))
            tbl.Columns.Add("Priority", GetType(Integer))
            tbl.Columns.Add("Duration", GetType(Integer))
            tbl.Columns.Add("Description", GetType(String))
            For i As Integer = 0 To 21 - 1
                Dim description As String = taskDescriptions(i)
                Dim index As Integer = description.IndexOf("."c)
                Dim subject As String
                If index <= 0 Then
                    subject = "task" & Convert.ToInt32(i + 1)
                Else
                    subject = description.Substring(0, index)
                End If

                tbl.Rows.Add(New Object() {i + 1, subject, RandomInstance.Next(3), RandomInstance.Next(3), Math.Max(1, RandomInstance.Next(8)), description})
            Next

            Return tbl
        End Function
    End Class
End Namespace
