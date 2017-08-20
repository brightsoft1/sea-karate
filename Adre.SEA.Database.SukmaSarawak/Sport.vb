Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Sport
    Public Sub New()
        Athletes = New HashSet(Of Athlete)()
        SportEvents = New HashSet(Of SportEvent)()
    End Sub

    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property SportID As Integer

    <Required>
    <StringLength(2)>
    Public Property SportCode As String

    <Required>
    <StringLength(100)>
    Public Property SportName As String

    Public Property TMQuota As Integer

    Public Property ATMQuota As Integer

    Public Property CoachQuota As Integer

    Public Property ACoachQuota As Integer

    Public Property MechanicQuota As Integer

    Public Property GMQuota As Integer

    Public Property TechDelQuota As Integer

    Public Property MaleQuota As Integer

    Public Property FemaleQuota As Integer

    Public Property NationalAthQuota As Integer

    Public Property AthMinAge As Byte

    Public Property AthMaxAge As Byte

    Public Property JudgeQuota As Integer

    Public Property AthEventQuota As Integer

    Public Property SortID As Integer

    Public Property Status As Byte

    Public Property FormType As Integer?

    Public Property PlayerCode As Integer?

    Public Property Gf3GelolaQuota As Integer

    Public Property Gf3TechQuota As Integer

    <StringLength(100)>
    Public Property GameName As String

    Public Property GameID As Integer?

    Public Property ChapQuota As Integer?

    <Column(TypeName:="date")>
    Public Property DateStart As Date?

    <Column(TypeName:="date")>
    Public Property DateEnd As Date?

    Public Overridable Property Athletes As ICollection(Of Athlete)

    Public Overridable Property SportEvents As ICollection(Of SportEvent)
End Class
