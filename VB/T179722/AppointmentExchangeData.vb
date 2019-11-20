Imports System
Imports System.Linq
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
			Subject = DirectCast(info.GetValue(NameOf(Subject), GetType(String)), String)
			Description = DirectCast(info.GetValue(NameOf(Description), GetType(String)), String)
			LabelKey = DirectCast(info.GetValue(NameOf(LabelKey), GetType(Integer)), Integer)
			StatusKey = DirectCast(info.GetValue(NameOf(StatusKey), GetType(Integer)), Integer)
			Start = DirectCast(info.GetValue(NameOf(Start), GetType(Date)), Date)
			Duration = DirectCast(info.GetValue(NameOf(Duration), GetType(TimeSpan)), TimeSpan)

		End Sub

		Public Property Subject() As String
		Public Property Description() As String
		Public Property LabelKey() As Integer
		Public Property StatusKey() As Integer
		Public Property Start() As Date
		Public Property Duration() As TimeSpan

		<SecurityCritical>
		Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
			info.AddValue(NameOf(Subject), Subject, GetType(String))
			info.AddValue(NameOf(Description), Description, GetType(String))
			info.AddValue(NameOf(LabelKey), LabelKey, GetType(Integer))
			info.AddValue(NameOf(StatusKey), StatusKey, GetType(Integer))
			info.AddValue(NameOf(Start), Start, GetType(Date))
			info.AddValue(NameOf(Duration), Duration, GetType(TimeSpan))
		End Sub

	End Class
End Namespace