Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Contingent
    Public Sub New()
        Athletes = New HashSet(Of Athlete)()
    End Sub

    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ContingentID As Integer

    <Required>
    <StringLength(50)>
    Public Property ContingentName As String

    <Required>
    <StringLength(3)>
    Public Property ContingentCode As String

    <Required>
    <StringLength(1)>
    Public Property ContingentType As String

    <StringLength(3)>
    Public Property ContingentPrefix As String

    Public Overridable Property Athletes As ICollection(Of Athlete)
End Class
