Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Athlete
    Public Property AthleteID As Integer

    <Required>
    <StringLength(150)>
    Public Property FullName As String

    <StringLength(30)>
    Public Property ADName As String

    Public Property ContingentID As Integer

    Public Property SportID As Integer

    Public Property IndexNo As Integer?

    <Required>
    <StringLength(1)>
    Public Property Gender As String

    <Column(TypeName:="smalldatetime")>
    Public Property DOB As Date

    Public Property FoodTypeID As Byte

    Public Property IsNationalAthlete As Boolean

    <StringLength(50)>
    Public Property UCICode As String

    <StringLength(100)>
    Public Property PicFile As String

    Public Property Status As Byte

    <Column(TypeName:="smalldatetime")>
    Public Property CreatedDateTime As Date

    Public Property CreatedUserID As Integer

    <Column(TypeName:="smalldatetime")>
    Public Property ModifiedDateTime As Date

    Public Property ModifiedUserID As Integer

    Public Property RFID As Long?

    Public Property FunctionID As Integer?

    Public Property ADPrint As Long?

    Public Property OrganizingID As Integer?

    <StringLength(50)>
    Public Property OrganizingName As String

    Public Property CardOut As Long?

    <StringLength(250)>
    Public Property CardTakenBy As String

    Public Property CardGivenBy As Integer?

    <Column(TypeName:="smalldatetime")>
    Public Property CardOutDate As Date?

    <StringLength(255)>
    Public Property CardRemark As String

    <StringLength(50)>
    Public Property CardOutID As String

    <StringLength(20)>
    Public Property PreferredName As String

    Public Overridable Property Contingent As Contingent

    Public Overridable Property Sport As Sport
End Class
