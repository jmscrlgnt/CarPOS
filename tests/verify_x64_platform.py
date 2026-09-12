from pathlib import Path

root = Path(__file__).resolve().parents[1]
sln = (root / 'CarDealershipPOS.sln').read_text(encoding='utf-8-sig')
proj = (root / 'CarDealershipPOS' / 'CarDealershipPOS.vbproj').read_text(encoding='utf-8-sig')

required_sln = [
    'Debug|x64 = Debug|x64',
    'Release|x64 = Release|x64',
    '.Debug|x64.ActiveCfg = Debug|x64',
    '.Debug|x64.Build.0 = Debug|x64',
    '.Release|x64.ActiveCfg = Release|x64',
    '.Release|x64.Build.0 = Release|x64',
]
for token in required_sln:
    assert token in sln, f'missing x64 solution mapping: {token}'

assert 'Debug|Any CPU' not in sln, 'solution still exposes Any CPU Debug configuration'
assert 'Release|Any CPU' not in sln, 'solution still exposes Any CPU Release configuration'

assert '<Platform Condition=" \'$(Platform)\' == \'\' ">x64</Platform>' in proj, 'default project platform is not x64'
assert "'Debug|x64'" in proj, 'project missing Debug|x64 property group'
assert "'Release|x64'" in proj, 'project missing Release|x64 property group'
assert "'Debug|AnyCPU'" not in proj, 'project still uses Debug|AnyCPU'
assert "'Release|AnyCPU'" not in proj, 'project still uses Release|AnyCPU'
assert '<PlatformTarget>x64</PlatformTarget>' in proj, 'x64 PlatformTarget missing'

print('x64 solution/project platform contract: PASS')
