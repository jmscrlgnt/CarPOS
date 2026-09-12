Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Data.Repositories
    Public NotInheritable Class VehicleRepository
        Public Function Search(searchText As String, condition As String, status As String) As DataTable
            Dim sql="SELECT Id,StockNumber,Brand,Model,Variant,ModelYear AS Year,Color,Condition,MileageKm AS Mileage,SellingPrice AS Price,Status FROM Vehicles WHERE 1=1"
            Dim parameters As New List(Of SQLiteParameter)()
            If Not String.IsNullOrWhiteSpace(searchText) Then sql &= " AND (StockNumber LIKE @q OR Vin LIKE @q OR Brand LIKE @q OR Model LIKE @q OR Variant LIKE @q)" : parameters.Add(New SQLiteParameter("@q","%" & searchText.Trim() & "%"))
            If condition<>"All" AndAlso Not String.IsNullOrWhiteSpace(condition) Then sql &= " AND Condition=@c" : parameters.Add(New SQLiteParameter("@c",condition))
            If status<>"All" AndAlso Not String.IsNullOrWhiteSpace(status) Then sql &= " AND Status=@s" : parameters.Add(New SQLiteParameter("@s",status))
            sql &= " ORDER BY CASE Status WHEN 'Available' THEN 0 WHEN 'Reserved' THEN 1 WHEN 'Sold' THEN 2 ELSE 3 END,Brand,Model"
            Return Database.Query(sql,parameters.ToArray())
        End Function
        Public Function GetById(id As Long) As Vehicle
            Dim t=Database.Query("SELECT * FROM Vehicles WHERE Id=@id",New SQLiteParameter("@id",id))
            If t.Rows.Count=0 Then Return Nothing
            Dim r=t.Rows(0)
            Return New Vehicle With {.Id=CLng(r("Id")),.StockNumber=CStr(r("StockNumber")),.Vin=If(r("Vin") Is DBNull.Value,"",CStr(r("Vin"))),.Brand=CStr(r("Brand")),.Model=CStr(r("Model")),.TrimLevel=If(r("Variant") Is DBNull.Value,"",CStr(r("Variant"))),.ModelYear=CInt(r("ModelYear")),.Color=If(r("Color") Is DBNull.Value,"",CStr(r("Color"))),.Condition=CStr(r("Condition")),.MileageKm=CInt(r("MileageKm")),.CostPrice=CDec(r("CostPrice")),.SellingPrice=CDec(r("SellingPrice")),.Status=CStr(r("Status")),.ImagePath=If(r("ImagePath") Is DBNull.Value,"",CStr(r("ImagePath"))),.Notes=If(r("Notes") Is DBNull.Value,"",CStr(r("Notes")))}
        End Function
        Public Function AvailableForSelection() As DataTable
            Return Database.Query("SELECT Id,StockNumber || ' · ' || ModelYear || ' ' || Brand || ' ' || Model || ' · ₱' || printf('%.2f',SellingPrice) AS Display FROM Vehicles WHERE Status='Available' ORDER BY Brand,Model")
        End Function
    End Class
End Namespace
