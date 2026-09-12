from pathlib import Path
import sys

root = Path(__file__).resolve().parents[1]
proj = root / 'CarDealershipPOS' / 'CarDealershipPOS.vbproj'
text = proj.read_text(encoding='utf-8', errors='ignore')
errors=[]

if 'System.Data.SQLite.Core' in text:
    errors.append('deprecated System.Data.SQLite.Core package still referenced')
if 'PackageReference Include="System.Data.SQLite"' not in text or '<Version>2.0.4</Version>' not in text:
    errors.append('System.Data.SQLite 2.0.4 package reference missing')
if 'PackageReference Include="SourceGear.sqlite3"' not in text or '<Version>3.53.4</Version>' not in text:
    errors.append('SourceGear.sqlite3 3.53.4 package reference missing')
if 'GeneratePathProperty="true"' not in text:
    errors.append('native package path property is not generated')
if text.count('<PlatformTarget>x64</PlatformTarget>') < 2:
    errors.append('Debug and Release are not pinned to x64')
if text.count('<Prefer32Bit>false</Prefer32Bit>') < 2:
    errors.append('Debug and Release do not explicitly disable Prefer32Bit')
if 'PkgSourceGear_sqlite3' not in text:
    errors.append('SourceGear package path is not used by build target')
if 'runtimes\\win-x64\\native\\e_sqlite3.dll' not in text:
    errors.append('x64 e_sqlite3 native DLL source path missing')
if '$(TargetDir)e_sqlite3.dll' not in text:
    errors.append('e_sqlite3.dll is not copied beside executable')
if 'AfterTargets="Build"' not in text:
    errors.append('native SQLite copy target is not scheduled after build')

if errors:
    print('FAIL')
    for e in errors:
        print('-', e)
    sys.exit(1)
print('PASS')
