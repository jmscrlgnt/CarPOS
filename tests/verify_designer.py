from pathlib import Path
import re,sys,xml.etree.ElementTree as ET
root=Path(__file__).resolve().parents[1]/'CarDealershipPOS'
forms=root/'Forms'; errors=[]
for code in forms.glob('*.vb'):
    if code.name.endswith('.Designer.vb') or code.name=='UiTheme.vb': continue
    designer=code.with_name(code.stem+'.Designer.vb'); resx=code.with_name(code.stem+'.resx')
    if not designer.exists() or not resx.exists(): errors.append(f'{code.name}: missing designer trio'); continue
    ds=designer.read_text(errors='ignore')
    cs=code.read_text(errors='ignore')
    if 'Namespace CarDealershipPOS' not in ds or 'Inherits System.Windows.Forms.Form' not in ds: errors.append(f'{designer.name}: missing Form namespace/base')
    if not re.search(r'Public\s+Partial\s+Class\s+'+re.escape(code.stem),cs,re.I): errors.append(f'{code.name}: root form is not public partial')
    if not re.search(r'Public\s+Sub\s+New\s*\(\s*\)',cs,re.I): errors.append(f'{code.name}: missing parameterless design constructor')
    if re.search(r'^\s*For\s+',ds,re.M): errors.append(f'{designer.name}: loop inside InitializeComponent')
    if re.search(r'^\s*Dim\s+\w+\s+As\s+New\s+(?:Label|Panel|GroupBox|Button|TextBox|ComboBox|DataGridView)',ds,re.M|re.I): errors.append(f'{designer.name}: anonymous local control in designer')
    try: ET.parse(resx)
    except Exception as e: errors.append(f'{resx.name}: invalid resx {e}')
if errors:
    print('FAIL'); [print('-',e) for e in errors]; sys.exit(1)
print('PASS: designer form trios and canonical InitializeComponent patterns')
