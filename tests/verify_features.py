from pathlib import Path
import re,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]
proj=root/'CarDealershipPOS'
errors=[]
allvb='\n'.join(p.read_text(errors='ignore') for p in proj.rglob('*.vb'))
for bad in ['Admin123','My.Settings.Password','My.Settings.UserBal','Dim tax As Double','Dim monthly As String = 0.083']:
    if bad.lower() in allvb.lower(): errors.append('legacy/security pattern: '+bad)
for feature,file in {
 'PBKDF2':'Security/PasswordSecurity.vb','first admin':'Forms/SetupAdminForm.vb','multi-brand inventory':'Services/InventoryService.vb','customers':'Services/CustomerService.vb','quotations':'Services/QuotationService.vb','atomic sales':'Services/SalesService.vb','installment ledger':'Services/PaymentService.vb','CSV export':'Services/ReportService.vb','backup restore':'Services/BackupService.vb','audit log':'Services/AuditService.vb'}.items():
    if not (proj/file).exists(): errors.append(f'missing {feature}: {file}')
required_tokens=['BeginTransaction','Status=\'Sold\'','QuotationItems','Payments','CreateBackup','ExportCsv','PBKDF2']
# PBKDF2 is represented by Rfc2898DeriveBytes
if 'Rfc2898DeriveBytes' not in allvb: errors.append('PBKDF2 implementation missing')
if 'BeginTransaction' not in allvb: errors.append('transactional checkout missing')
if "Status='Sold'" not in allvb: errors.append('sold status update missing')
if 'CreateBackup' not in allvb or 'ExportCsv' not in allvb: errors.append('backup/export feature missing')
# project XML and configuration
try:
    tree=ET.parse(proj/'CarDealershipPOS.vbproj')
except Exception as e: errors.append('invalid vbproj: '+str(e))
text=(proj/'CarDealershipPOS.vbproj').read_text()
if "Debug|x64" not in text or '<StartupObject>CarDealershipPOS.Program</StartupObject>' not in text: errors.append('solution/project startup configuration incomplete')
if 'PackageReference Include="System.Data.SQLite"' not in text or 'PackageReference Include="SourceGear.sqlite3"' not in text: errors.append('SQLite 2.x managed/native PackageReferences missing')
# make sure all vb files are included
for p in proj.rglob('*.vb'):
    rel=str(p.relative_to(proj)).replace('/','\\')
    if f'Include="{rel}"' not in text: errors.append('vbproj missing compile item '+rel)
# no oversized paths
for p in root.rglob('*'):
    if p.is_file() and len(str(p.relative_to(root)))>150: errors.append('long path '+str(p.relative_to(root)))
if errors:
    print('FAIL'); [print('-',e) for e in errors]; sys.exit(1)
print('PASS: modernization features/security/project configuration')
