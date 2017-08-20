Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class SportEvent
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property EventID As Integer

    Public Property SportID As Integer

    <Required>
    <StringLength(150)>
    Public Property EventName As String

    <Required>
    <StringLength(1)>
    Public Property EventGender As String

    <Required>
    <StringLength(1)>
    Public Property EventType As String

    <StringLength(50)>
    Public Property EventCode_2 As String

    Public Property EventQuota As Integer

    <Required>
    <StringLength(10)>
    Public Property EventCode As String

    <StringLength(200)>
    Public Property NR As String

    <StringLength(200)>
    Public Property GR As String

    <StringLength(50)>
    Public Property SeasonBest As String

    <StringLength(50)>
    Public Property SeasonBestDate As String

    '<StringLength(50)>
    'Public Property BestPerformance As String

    '<StringLength(50)>
    'Public Property BestPerformanceDate As String

    Public Overridable Property Sport As Sport
End Class
