Imports System
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization
Imports System.Security

Namespace T179722

    <Serializable>
    <ComVisible(True)>
    <SecurityCritical>
    Public Class AppointmentExchangeData
        Implements ISerializable

        Public Sub New()
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            Subject = CStr(info.GetValue(NameOf(AppointmentExchangeData.Subject), GetType(String)))
            Description = CStr(info.GetValue(NameOf(AppointmentExchangeData.Description), GetType(String)))
            LabelKey = CInt(info.GetValue(NameOf(AppointmentExchangeData.LabelKey), GetType(Integer)))
            StatusKey = CInt(info.GetValue(NameOf(AppointmentExchangeData.StatusKey), GetType(Integer)))
            Start = CDate(info.GetValue(NameOf(AppointmentExchangeData.Start), GetType(Date)))
            Duration = CType(info.GetValue(NameOf(AppointmentExchangeData.Duration), GetType(TimeSpan)), TimeSpan)
        End Sub

        Public Property Subject As String

        Public Property Description As String

        Public Property LabelKey As Integer

        Public Property StatusKey As Integer

        Public Property Start As Date

        Public Property Duration As TimeSpan

        <SecurityCritical>
        Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
            info.AddValue(NameOf(AppointmentExchangeData.Subject), Subject, GetType(String))
            info.AddValue(NameOf(AppointmentExchangeData.Description), Description, GetType(String))
            info.AddValue(NameOf(AppointmentExchangeData.LabelKey), LabelKey, GetType(Integer))
            info.AddValue(NameOf(AppointmentExchangeData.StatusKey), StatusKey, GetType(Integer))
            info.AddValue(NameOf(AppointmentExchangeData.Start), Start, GetType(Date))
            info.AddValue(NameOf(AppointmentExchangeData.Duration), Duration, GetType(TimeSpan))
        End Sub
    End Class
End Namespace
