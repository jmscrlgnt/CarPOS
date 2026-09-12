Imports System
Imports System.Data
Imports System.Data.SQLite
Imports CarDealershipPOS.Data
Imports CarDealershipPOS.Data.Repositories
Imports CarDealershipPOS.Models

Namespace CarDealershipPOS.Services
    Public NotInheritable Class InventoryService
        Private ReadOnly _audit As New AuditService()
        Private ReadOnly _repo As New VehicleRepository()

        Public Function Search(searchText As String, condition As String, status As String) As DataTable
            Return _repo.Search(searchText,condition,status)
        End Function

        Public Function AvailableForSelection() As DataTable
            Return _repo.AvailableForSelection()
        End Function

        Public Function GetById(id As Long) As Vehicle
            Return _repo.GetById(id)
        End Function

        Public Function Save(vehicle As Vehicle) As String
            If vehicle Is Nothing Then Return "Vehicle is required."
            If String.IsNullOrWhiteSpace(vehicle.StockNumber) OrElse String.IsNullOrWhiteSpace(vehicle.Brand) OrElse String.IsNullOrWhiteSpace(vehicle.Model) Then Return "Stock number, brand, and model are required."
            If vehicle.ModelYear < 1950 OrElse vehicle.ModelYear > DateTime.Today.Year + 2 Then Return "Model year is invalid."
            If vehicle.SellingPrice <= 0D Then Return "Selling price must be greater than zero."
            If vehicle.Condition <> "New" AndAlso vehicle.Condition <> "Used" Then Return "Condition must be New or Used."
            If vehicle.Condition = "New" Then vehicle.MileageKm = Math.Max(0, vehicle.MileageKm)
            Dim dup = Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles WHERE StockNumber=@s AND Id<>@id", New SQLiteParameter("@s",vehicle.StockNumber.Trim()), New SQLiteParameter("@id",vehicle.Id))
            If dup > 0 Then Return "Stock number already exists."
            If Not String.IsNullOrWhiteSpace(vehicle.Vin) Then
                dup = Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles WHERE Vin=@v AND Id<>@id", New SQLiteParameter("@v",vehicle.Vin.Trim()), New SQLiteParameter("@id",vehicle.Id))
                If dup > 0 Then Return "VIN already exists."
            End If
            Dim now=DateTime.UtcNow.ToString("o")
            If vehicle.Id=0 Then
                Database.Execute("INSERT INTO Vehicles(StockNumber,Vin,Brand,Model,Variant,ModelYear,Color,Condition,MileageKm,CostPrice,SellingPrice,Status,ImagePath,Notes,CreatedAtUtc,UpdatedAtUtc) VALUES(@sn,@vin,@b,@m,@v,@y,@c,@cond,@km,@cost,@sell,'Available',@img,@notes,@n,@n)",
                    New SQLiteParameter("@sn",vehicle.StockNumber.Trim()),New SQLiteParameter("@vin",NullDb(vehicle.Vin)),New SQLiteParameter("@b",vehicle.Brand.Trim()),New SQLiteParameter("@m",vehicle.Model.Trim()),New SQLiteParameter("@v",NullDb(vehicle.TrimLevel)),New SQLiteParameter("@y",vehicle.ModelYear),New SQLiteParameter("@c",NullDb(vehicle.Color)),New SQLiteParameter("@cond",vehicle.Condition),New SQLiteParameter("@km",vehicle.MileageKm),New SQLiteParameter("@cost",vehicle.CostPrice),New SQLiteParameter("@sell",vehicle.SellingPrice),New SQLiteParameter("@img",NullDb(vehicle.ImagePath)),New SQLiteParameter("@notes",NullDb(vehicle.Notes)),New SQLiteParameter("@n",now))
                _audit.Write("Vehicle created","Vehicle",Nothing,"Stock=" & vehicle.StockNumber)
            Else
                Database.Execute("UPDATE Vehicles SET StockNumber=@sn,Vin=@vin,Brand=@b,Model=@m,Variant=@v,ModelYear=@y,Color=@c,Condition=@cond,MileageKm=@km,CostPrice=@cost,SellingPrice=@sell,ImagePath=@img,Notes=@notes,UpdatedAtUtc=@n WHERE Id=@id AND Status<>'Sold'",
                    New SQLiteParameter("@sn",vehicle.StockNumber.Trim()),New SQLiteParameter("@vin",NullDb(vehicle.Vin)),New SQLiteParameter("@b",vehicle.Brand.Trim()),New SQLiteParameter("@m",vehicle.Model.Trim()),New SQLiteParameter("@v",NullDb(vehicle.TrimLevel)),New SQLiteParameter("@y",vehicle.ModelYear),New SQLiteParameter("@c",NullDb(vehicle.Color)),New SQLiteParameter("@cond",vehicle.Condition),New SQLiteParameter("@km",vehicle.MileageKm),New SQLiteParameter("@cost",vehicle.CostPrice),New SQLiteParameter("@sell",vehicle.SellingPrice),New SQLiteParameter("@img",NullDb(vehicle.ImagePath)),New SQLiteParameter("@notes",NullDb(vehicle.Notes)),New SQLiteParameter("@n",now),New SQLiteParameter("@id",vehicle.Id))
                _audit.Write("Vehicle updated","Vehicle",vehicle.Id.ToString(),"Stock=" & vehicle.StockNumber)
            End If
            Return Nothing
        End Function

        Public Function SetInactive(id As Long) As String
            Dim status=Database.Scalar(Of String)("SELECT Status FROM Vehicles WHERE Id=@id",New SQLiteParameter("@id",id))
            If status Is Nothing Then Return "Vehicle not found."
            If status="Sold" Then Return "Sold vehicles cannot be deactivated."
            Database.Execute("UPDATE Vehicles SET Status='Inactive',UpdatedAtUtc=@n WHERE Id=@id",New SQLiteParameter("@n",DateTime.UtcNow.ToString("o")),New SQLiteParameter("@id",id))
            _audit.Write("Vehicle deactivated","Vehicle",id.ToString())
            Return Nothing
        End Function

        Public Sub SeedDemoInventory()
            Dim count=Database.Scalar(Of Long)("SELECT COUNT(*) FROM Vehicles")
            If count>0 Then Return
            Dim demo = New Vehicle() {
                New Vehicle With {.StockNumber="NEW-TOY-001",.Brand="Toyota",.Model="GR Supra",.TrimLevel="RZ",.ModelYear=2026,.Color="White",.Condition="New",.SellingPrice=5396000D},
                New Vehicle With {.StockNumber="NEW-TOY-002",.Brand="Toyota",.Model="GR86",.TrimLevel="Premium",.ModelYear=2026,.Color="Red",.Condition="New",.SellingPrice=2328000D},
                New Vehicle With {.StockNumber="NEW-HON-001",.Brand="Honda",.Model="Civic",.TrimLevel="RS Turbo",.ModelYear=2026,.Color="Gray",.Condition="New",.SellingPrice=1870000D},
                New Vehicle With {.StockNumber="NEW-MIT-001",.Brand="Mitsubishi",.Model="Montero Sport",.TrimLevel="GT 4WD",.ModelYear=2026,.Color="Black",.Condition="New",.SellingPrice=2580000D},
                New Vehicle With {.StockNumber="NEW-FOR-001",.Brand="Ford",.Model="Ranger",.TrimLevel="Wildtrak",.ModelYear=2026,.Color="Blue",.Condition="New",.SellingPrice=2038000D},
                New Vehicle With {.StockNumber="USED-TOY-001",.Brand="Toyota",.Model="Vios",.TrimLevel="G",.ModelYear=2022,.Color="Silver",.Condition="Used",.MileageKm=41000,.SellingPrice=650000D},
                New Vehicle With {.StockNumber="USED-HON-001",.Brand="Honda",.Model="City",.TrimLevel="VX",.ModelYear=2021,.Color="White",.Condition="Used",.MileageKm=52000,.SellingPrice=720000D},
                New Vehicle With {.StockNumber="USED-FOR-001",.Brand="Ford",.Model="Everest",.TrimLevel="Titanium",.ModelYear=2020,.Color="Black",.Condition="Used",.MileageKm=68000,.SellingPrice=1250000D}
            }
            For Each v In demo : Save(v) : Next
            _audit.Write("Demo inventory seeded","Vehicle",Nothing,demo.Length.ToString() & " vehicles")
        End Sub

        Private Shared Function NullDb(value As String) As Object
            Return If(String.IsNullOrWhiteSpace(value), CType(DBNull.Value,Object), value.Trim())
        End Function
    End Class
End Namespace
