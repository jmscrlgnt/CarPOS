import subprocess,sys
from pathlib import Path
here=Path(__file__).resolve().parent
scripts=['verify_project.py','verify_designer.py','verify_features.py','verify_schema_workflow.py','verify_vb_structure.py','verify_static_sanity.py','verify_pos_runtime_safety.py','verify_vehicle_images_phase1.py','verify_ui_phase2.py','verify_sqlite_runtime.py','verify_x64_platform.py']
for s in scripts:
    print('==',s,'==')
    r=subprocess.run([sys.executable,str(here/s)])
    if r.returncode: sys.exit(r.returncode)
print('ALL CHECKS PASS')
