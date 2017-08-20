Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class WSLSSContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=WSLSSContext")
    End Sub

    Public Overridable Property AthleteEvents As DbSet(Of AthleteEvent)
    Public Overridable Property Athletes As DbSet(Of Athlete)
    Public Overridable Property Contingents As DbSet(Of Contingent)
    Public Overridable Property SportEvents As DbSet(Of SportEvent)
    Public Overridable Property Sports As DbSet(Of Sport)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Athlete)() _
            .Property(Function(e) e.Gender) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of Athlete)() _
            .Property(Function(e) e.UCICode) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Athlete)() _
            .Property(Function(e) e.PicFile) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Athlete)() _
            .Property(Function(e) e.PreferredName) _
            .IsFixedLength()

        modelBuilder.Entity(Of Contingent)() _
            .Property(Function(e) e.ContingentName) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Contingent)() _
            .Property(Function(e) e.ContingentCode) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Contingent)() _
            .Property(Function(e) e.ContingentType) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of Contingent)() _
            .Property(Function(e) e.ContingentPrefix) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Contingent)() _
            .HasMany(Function(e) e.Athletes) _
            .WithRequired(Function(e) e.Contingent) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of SportEvent)() _
            .Property(Function(e) e.EventGender) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of SportEvent)() _
            .Property(Function(e) e.EventType) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of Sport)() _
            .Property(Function(e) e.SportCode) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Sport)() _
            .HasMany(Function(e) e.Athletes) _
            .WithRequired(Function(e) e.Sport) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Sport)() _
            .HasMany(Function(e) e.SportEvents) _
            .WithRequired(Function(e) e.Sport) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
