Imports System
Imports System.Globalization
Imports System.Windows.Forms
Imports CarDealershipPOS.Services

Namespace CarDealershipPOS
    Public Partial Class SettingsForm
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub SettingsForm_Load(sender As Object,e As EventArgs) Handles MyBase.Load
            Dim s As New SettingsService()
            txtName.Text=s.GetValue("DealershipName","AutoDrive Dealership"):txtAddress.Text=s.GetValue("Address",""):txtContact.Text=s.GetValue("ContactNumber",""):txtFooter.Text=s.GetValue("ReceiptFooter","Thank you for choosing us.")
            Dim rate As Decimal=12D:Decimal.TryParse(s.GetValue("TaxRate","12.00"),NumberStyles.Number,CultureInfo.InvariantCulture,rate):numTax.Value=Math.Max(numTax.Minimum,Math.Min(numTax.Maximum,rate))
            grpAdmin.Enabled=SessionContext.IsAdministrator
            txtName.Enabled=SessionContext.IsAdministrator:txtAddress.Enabled=SessionContext.IsAdministrator:txtContact.Enabled=SessionContext.IsAdministrator:txtFooter.Enabled=SessionContext.IsAdministrator:numTax.Enabled=SessionContext.IsAdministrator:btnSave.Enabled=SessionContext.IsAdministrator
            lblRole.Text="Signed in as " & SessionContext.Username & " · " & SessionContext.Role
        End Sub
        Private Sub btnSave_Click(sender As Object,e As EventArgs) Handles btnSave.Click
            Dim s As New SettingsService():s.SetValue("DealershipName",txtName.Text.Trim()):s.SetValue("Address",txtAddress.Text.Trim()):s.SetValue("ContactNumber",txtContact.Text.Trim()):s.SetValue("ReceiptFooter",txtFooter.Text.Trim()):s.SetValue("TaxRate",numTax.Value.ToString(CultureInfo.InvariantCulture))
            MessageBox.Show("Settings saved.","Settings",MessageBoxButtons.OK,MessageBoxIcon.Information)
        End Sub
        Private Sub btnUsers_Click(sender As Object,e As EventArgs) Handles btnUsers.Click
            Using f As New UserManagementForm():f.ShowDialog():End Using
        End Sub
        Private Sub btnAudit_Click(sender As Object,e As EventArgs) Handles btnAudit.Click
            Using f As New AuditLogForm():f.ShowDialog():End Using
        End Sub
        Private Sub btnBackup_Click(sender As Object,e As EventArgs) Handles btnBackup.Click
            Using d As New SaveFileDialog() With {.Filter="SQLite Database|*.db",.FileName="dealership-backup-" & DateTime.Now.ToString("yyyyMMdd-HHmmss") & ".db"}
                If d.ShowDialog() = DialogResult.OK Then
                    Dim backupService As New BackupService()
                    backupService.CreateBackup(d.FileName)
                    MessageBox.Show("Backup created successfully.")
                End If
            End Using
        End Sub
        Private Sub btnRestore_Click(sender As Object,e As EventArgs) Handles btnRestore.Click
            Using d As New OpenFileDialog() With {.Filter="SQLite Database|*.db|All Files|*.*"}
                If d.ShowDialog()<>DialogResult.OK Then Return
                If MessageBox.Show("Restore this backup? A safety backup of the current database will be created first.","Restore",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)<>DialogResult.Yes Then Return
                Try
                    Dim backupService As New BackupService()
                    backupService.Restore(d.FileName)
                    MessageBox.Show("Database restored. Restart the application to reload all data.")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Sub
    End Class
End Namespace
