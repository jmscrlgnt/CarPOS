from pathlib import Path
import re,sys
root=Path(__file__).resolve().parents[1]/'CarDealershipPOS'
p=root/'Forms'/'PosForm.vb'
s=p.read_text(errors='ignore')
errors=[]

# Loading/binding must not let SelectedIndexChanged run against a half-bound ComboBox.
if not re.search(r'Private\s+_loadingSelections\s+As\s+Boolean',s,re.I):
    errors.append('PosForm must have a _loadingSelections guard')

# Customer binding order: Display/Value before DataSource.
for name,source_name in (('cbCustomer','customers'),('cbVehicle','vehicles')):
    dm=s.find(f'{name}.DisplayMember')
    vm=s.find(f'{name}.ValueMember')
    ds=s.find(f'{name}.DataSource = {source_name}')
    if min(dm,vm,ds) < 0 or not (dm < ds and vm < ds):
        errors.append(f'{name} must set DisplayMember and ValueMember before DataSource')

# Selection event handlers must ignore initialization events.
handler=re.search(r'Private\s+Sub\s+cbVehicle_SelectedIndexChanged.*?End\s+Sub',s,re.I|re.S)
if not handler or not re.search(r'If\s+_loadingSelections\s+Then\s+Return',handler.group(0),re.I):
    errors.append('cbVehicle_SelectedIndexChanged must return while selections are loading')

# SelectedValue conversion must reject temporary DataRowView values instead of CLng-casting blindly.
if 'DataRowView' not in s:
    errors.append('PosForm must explicitly handle temporary DataRowView SelectedValue values')
if re.search(r'Return\s+CLng\(cb(?:Customer|Vehicle)\.SelectedValue\)',s,re.I):
    errors.append('SelectedValue must not be directly CLng-cast')

# Actions should be gated on valid customer + vehicle selections.
if not re.search(r'Private\s+Sub\s+UpdateActionState\s*\(',s,re.I):
    errors.append('PosForm must centralize quote/finalize enabled state')

if errors:
    print('FAIL')
    for e in errors: print('-',e)
    sys.exit(1)
print('PASS: POS ComboBox binding/runtime selection safety')
