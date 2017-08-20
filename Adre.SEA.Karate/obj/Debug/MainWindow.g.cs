﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BE8D8A09A38DB3D680D50F95972C70B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Adre.Controls.Bracket;
using Adre.Controls.RankingList;
using Adre.Controls.ResultList.TeamVSTeam;
using Adre.Controls.StartList.TeamVSTeam;
using Adre.SEA.Importer;
using Adre.SEA.Karate;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Adre.SEA.Karate {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Adre.SEA.Karate;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 42 "..\..\MainWindow.xaml"
            ((Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl)(target)).OnNewItemAdded += new Adre.Controls.StartList.TeamVSTeam.NewItemAddedHandler(this.OnNewItemAdded);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            ((Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataContextBinded += new Adre.Controls.StartList.TeamVSTeam.DataContextBindingHandler(this.OnStartListDataBinded);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            ((Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataSaved += new Adre.Controls.StartList.TeamVSTeam.DataSavedHandler(this.OnStartListSaved);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            ((Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl)(target)).OnItemDeleted += new Adre.Controls.StartList.TeamVSTeam.ItemDeletedHandler(this.OnStartListItemDeleted);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            ((Adre.Controls.StartList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataRefreshed += new Adre.Controls.StartList.TeamVSTeam.OnDataRefreshedHandler(this.OnStartListDataRefreshed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\MainWindow.xaml"
            ((Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataContextBinded += new Adre.Controls.ResultList.TeamVSTeam.DataContextBindingHandler(this.OnResultListDataBinded);
            
            #line default
            #line hidden
            
            #line 45 "..\..\MainWindow.xaml"
            ((Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataSaved += new Adre.Controls.ResultList.TeamVSTeam.DataSavedHandler(this.OnResultListSaved);
            
            #line default
            #line hidden
            
            #line 45 "..\..\MainWindow.xaml"
            ((Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataRefreshed += new Adre.Controls.ResultList.TeamVSTeam.DataRefreshedHandler(this.OnResultListDataRefreshed);
            
            #line default
            #line hidden
            
            #line 45 "..\..\MainWindow.xaml"
            ((Adre.Controls.ResultList.TeamVSTeam.TeamVSTeamControl)(target)).OnDataRowDoubleClicked += new Adre.Controls.ResultList.TeamVSTeam.RowDoubleClickedHandler(this.OnResultListRowDoubleClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 48 "..\..\MainWindow.xaml"
            ((Adre.Controls.RankingList.RankingListControl)(target)).OnDataContextBinded += new Adre.Controls.RankingList.DataContextBindedHandler(this.OnRankingDataContextBinded);
            
            #line default
            #line hidden
            
            #line 48 "..\..\MainWindow.xaml"
            ((Adre.Controls.RankingList.RankingListControl)(target)).OnDataSaved += new Adre.Controls.RankingList.DataSavedHandler(this.OnRankingListSave);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 51 "..\..\MainWindow.xaml"
            ((Adre.SEA.Importer.MainControl)(target)).OnStatusChanged += new Adre.SEA.Importer.StatusChangedHandler(this.OnImporterStatusChanged);
            
            #line default
            #line hidden
            
            #line 51 "..\..\MainWindow.xaml"
            ((Adre.SEA.Importer.MainControl)(target)).OnStatusChanging += new Adre.SEA.Importer.StatusChangedHandler(this.OnImporterStatusChanging);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

