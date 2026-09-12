Imports System
Imports System.Drawing
Imports System.IO
Imports System.Text

Namespace CarDealershipPOS.Utilities
    Public NotInheritable Class VehicleImageStorage
        Private Shared ReadOnly AllowedExtensions As String() = {".jpg", ".jpeg", ".png", ".bmp", ".gif"}

        Private Sub New()
        End Sub

        Public Shared Function CopyIntoLibrary(sourcePath As String, stockNumber As String) As String
            If String.IsNullOrWhiteSpace(sourcePath) OrElse Not File.Exists(sourcePath) Then
                Throw New FileNotFoundException("The selected vehicle image could not be found.", sourcePath)
            End If

            Dim extension As String = Path.GetExtension(sourcePath).ToLowerInvariant()
            If Array.IndexOf(AllowedExtensions, extension) < 0 Then
                Throw New InvalidOperationException("Supported vehicle images are JPG, JPEG, PNG, BMP, and GIF files.")
            End If

            AppPaths.EnsureDirectories()
            Dim safeStock As String = SanitizeFileName(stockNumber)
            If String.IsNullOrWhiteSpace(safeStock) Then safeStock = "vehicle"
            Dim fileName As String = String.Format("{0}_{1}{2}", safeStock, DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"), extension)
            Dim destination As String = Path.Combine(AppPaths.VehicleImageDirectory, fileName)
            File.Copy(sourcePath, destination, False)
            Return fileName
        End Function

        Public Shared Function ResolvePath(storedPath As String) As String
            If String.IsNullOrWhiteSpace(storedPath) Then Return Nothing
            If Path.IsPathRooted(storedPath) Then Return storedPath
            Return Path.Combine(AppPaths.VehicleImageDirectory, storedPath)
        End Function

        Public Shared Function LoadImageClone(storedPath As String) As Image
            Dim resolved As String = ResolvePath(storedPath)
            If String.IsNullOrWhiteSpace(resolved) OrElse Not File.Exists(resolved) Then Return Nothing

            Try
                Using stream As New FileStream(resolved, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    Using source As Image = Image.FromStream(stream)
                        Return New Bitmap(source)
                    End Using
                End Using
            Catch
                Return Nothing
            End Try
        End Function

        Public Shared Sub DeleteManagedImage(storedPath As String)
            If String.IsNullOrWhiteSpace(storedPath) Then Return

            Dim resolved As String = ResolvePath(storedPath)
            If String.IsNullOrWhiteSpace(resolved) Then Return

            Dim libraryRoot As String = Path.GetFullPath(AppPaths.VehicleImageDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) & Path.DirectorySeparatorChar
            Dim candidate As String = Path.GetFullPath(resolved)
            If Not candidate.StartsWith(libraryRoot, StringComparison.OrdinalIgnoreCase) Then Return

            Try
                If File.Exists(candidate) Then File.Delete(candidate)
            Catch
                ' Image cleanup must never make a successfully saved vehicle fail.
            End Try
        End Sub

        Public Shared Function SanitizeFileName(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then Return String.Empty
            Dim invalid As Char() = Path.GetInvalidFileNameChars()
            Dim builder As New StringBuilder()
            For Each ch As Char In value.Trim()
                If Array.IndexOf(invalid, ch) >= 0 OrElse Char.IsWhiteSpace(ch) Then
                    builder.Append("_"c)
                Else
                    builder.Append(ch)
                End If
            Next
            Return builder.ToString()
        End Function
    End Class
End Namespace
