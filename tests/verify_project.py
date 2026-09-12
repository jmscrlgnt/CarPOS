from pathlib import Path
import re, sys, sqlite3
root=Path(__file__).resolve().parents[1]
proj=root/'CarDealershipPOS'
errors=[]
required=[
 'CarDealershipPOS.vbproj','App.config','Program.vb',
 'Data/Database.vb','Security/PasswordSecurity.vb','Services/AuthService.vb',
 'Services/InventoryService.vb','Services/CustomerService.vb','Services/QuotationService.vb',
 'Services/SalesService.vb','Services/PaymentService.vb','Services/ReportService.vb',
 'Forms/LoginForm.vb','Forms/LoginForm.Designer.vb','Forms/LoginForm.resx',
 'Forms/MainForm.vb','Forms/MainForm.Designer.vb','Forms/MainForm.resx',
 'Forms/DashboardForm.vb','Forms/InventoryForm.vb','Forms/CustomersForm.vb',
 'Forms/PosForm.vb','Forms/QuotationsForm.vb','Forms/SalesForm.vb','Forms/PaymentsForm.vb','Forms/SettingsForm.vb'
]
for r in required:
    if not (proj/r).exists(): errors.append('missing '+r)
# SourceGear.sqlite3 rejects Any CPU builds, so the project must use x64
# for both Debug and Release
# with explicit OutputPath blocks.
vbproj=proj/'CarDealershipPOS.vbproj'
if vbproj.exists():
    project_text=vbproj.read_text(errors='ignore')
    for cfg, out in [('Debug','bin\\Debug\\'),('Release','bin\\Release\\')]:
        cond=f"'{cfg}|x64'"
        if cond not in project_text or f'<OutputPath>{out}</OutputPath>' not in project_text:
            errors.append(f'missing {cfg}|x64 OutputPath')

if proj.exists():
    txt='\n'.join(p.read_text(errors='ignore') for p in proj.rglob('*.vb'))
    if 'Admin123' in txt: errors.append('hardcoded Admin123')
    if re.search(r'\bDouble\b.*(?:Price|Amount|Total|Tax|Balance)',txt,re.I): errors.append('money uses Double')
    if 'My.Settings.Password' in txt: errors.append('legacy plaintext password settings')
    forms=list((proj/'Forms').glob('*.vb')) if (proj/'Forms').exists() else []
    roots=[p for p in forms if not p.name.endswith('.Designer.vb') and p.name != 'UiTheme.vb']
    for f in roots:
        d=f.with_name(f.stem+'.Designer.vb'); r=f.with_name(f.stem+'.resx')
        if not d.exists() or not r.exists(): errors.append('designer trio missing for '+f.name)
schema=proj/'Data/schema.sql'
if schema.exists():
    con=sqlite3.connect(':memory:')
    try: con.executescript(schema.read_text())
    except Exception as e: errors.append('schema invalid '+str(e))
    tables={r[0] for r in con.execute("select name from sqlite_master where type='table'")}
    for t in ['Users','Customers','Vehicles','Quotations','QuotationItems','Sales','SaleItems','Payments','Settings','AuditLogs']:
        if t not in tables: errors.append('missing table '+t)
if errors:
    print('FAIL')
    for e in errors: print('-',e)
    sys.exit(1)
print('PASS')
