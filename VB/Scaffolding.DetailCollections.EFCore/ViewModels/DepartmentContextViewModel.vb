﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.ViewModel
Imports Scaffolding.DetailCollections.EFCore.Localization
Imports Scaffolding.DetailCollections.EFCore.DepartmentContextDataModel

Namespace Scaffolding.DetailCollections.EFCore.ViewModels
	''' <summary>
	''' Represents the root POCO view model for the DepartmentContext data model.
	''' </summary>
	Partial Public Class DepartmentContextViewModel
		Inherits DocumentsViewModel(Of DepartmentContextModuleDescription, IDepartmentContextUnitOfWork)

		Private Const TablesGroup As String = "Tables"

		Private Const ViewsGroup As String = "Views"

		''' <summary>
		''' Creates a new instance of DepartmentContextViewModel as a POCO view model.
		''' </summary>
		Public Shared Function Create() As DepartmentContextViewModel
			Return ViewModelSource.Create(Function() New DepartmentContextViewModel())
		End Function

		Shared Sub New()
			MetadataLocator.Default = MetadataLocator.Create().AddMetadata(Of DepartmentContextMetadataProvider)()
		End Sub
		''' <summary>
		''' Initializes a new instance of the DepartmentContextViewModel class.
		''' This constructor is declared protected to avoid undesired instantiation of the DepartmentContextViewModel type without the POCO proxy factory.
		''' </summary>
		Protected Sub New()
			MyBase.New(UnitOfWorkSource.GetUnitOfWorkFactory())
		End Sub

		Protected Overrides Function CreateModules() As DepartmentContextModuleDescription()
			Return New DepartmentContextModuleDescription() {
				New DepartmentContextModuleDescription(DepartmentContextResources.CoursePlural, "CourseCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Courses)),
				New DepartmentContextModuleDescription(DepartmentContextResources.DepartmentPlural, "DepartmentCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Departments)),
				New DepartmentContextModuleDescription(DepartmentContextResources.EmployeePlural, "EmployeeCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(Function(x) x.Employees))
			}
		End Function
	End Class

	Partial Public Class DepartmentContextModuleDescription
		Inherits ModuleDescription(Of DepartmentContextModuleDescription)

		Public Sub New(ByVal title As String, ByVal documentType As String, ByVal group As String, Optional ByVal peekCollectionViewModelFactory As Func(Of DepartmentContextModuleDescription, Object) = Nothing)
			MyBase.New(title, documentType, group, peekCollectionViewModelFactory)
		End Sub
	End Class
End Namespace