from pathlib import Path
import sys
root=Path(__file__).resolve().parents[1]/'CarDealershipPOS'
errors=[]

def text(rel):
    p=root/rel
    if not p.exists():
        errors.append('missing '+rel)
        return ''
    return p.read_text(errors='ignore')

app=text('Utilities/AppPaths.vb')
if 'VehicleImageDirectory' not in app: errors.append('AppPaths.VehicleImageDirectory missing')
if 'Directory.CreateDirectory(VehicleImageDirectory)' not in app: errors.append('VehicleImages directory not created')

storage=text('Utilities/VehicleImageStorage.vb')
for token in ['CopyIntoLibrary','LoadImageClone','DeleteManagedImage','SanitizeFileName']:
    if token not in storage: errors.append('VehicleImageStorage missing '+token)

editor=text('Forms/VehicleEditorForm.Designer.vb')+'\n'+text('Forms/VehicleEditorForm.vb')
for token in ['picVehicle','btnChooseImage','btnRemoveImage','ShowImagePreview','CopyIntoLibrary']:
    if token not in editor: errors.append('vehicle editor image feature missing '+token)

inv=text('Forms/InventoryForm.Designer.vb')+'\n'+text('Forms/InventoryForm.vb')
for token in ['picVehiclePreview','lblPreviewName','lblPreviewPrice','lblNoImage','gridVehicles_SelectionChanged','LoadImageClone']:
    if token not in inv: errors.append('inventory preview missing '+token)

schema=text('Data/schema.sql')
model=text('Models/Vehicle.vb')
repo=text('Data/Repositories/VehicleRepository.vb')
service=text('Services/InventoryService.vb')
if 'ImagePath TEXT' not in schema: errors.append('Vehicles.ImagePath schema missing')
if 'Property ImagePath As String' not in model: errors.append('Vehicle.ImagePath model missing')
if '.ImagePath=' not in repo: errors.append('Vehicle repository does not read ImagePath')
if '@img' not in service: errors.append('InventoryService does not persist ImagePath')

proj=text('CarDealershipPOS.vbproj')
if 'Utilities\\VehicleImageStorage.vb' not in proj: errors.append('VehicleImageStorage not included in vbproj')

if errors:
    print('FAIL')
    for e in errors: print('-',e)
    sys.exit(1)
print('PASS: vehicle image Phase 1 structure')
