Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class AthleteEvent
    Public Property AthleteEventID As Integer

    Public Property AthleteID As Integer

    Public Property EventID As Integer

    <StringLength(50)>
    Public Property Position As String

    <StringLength(50)>
    Public Property BestPerformance As String

    <StringLength(50)>
    Public Property BestPerformanceDate As String

    <StringLength(50)>
    Public Property SeasonBest As String

    <StringLength(50)>
    Public Property SeasonBestDate As String
End Class
