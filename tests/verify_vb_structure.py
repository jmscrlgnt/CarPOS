from pathlib import Path
import re,sys
root=Path(__file__).resolve().parents[1]/'CarDealershipPOS'; errors=[]
for p in root.rglob('*.vb'):
    s=p.read_text(errors='ignore')
    pairs=[('Namespace','End Namespace'),('Class','End Class'),('Sub','End Sub'),('Function','End Function')]
    # count only declarations; exclude End lines and words in comments/strings approximately
    ns=len(re.findall(r'^\s*Namespace\s+',s,re.M|re.I)); ens=len(re.findall(r'^\s*End\s+Namespace\b',s,re.M|re.I))
    cl=len(re.findall(r'^\s*(?:Public\s+|Private\s+|Friend\s+|Protected\s+|Partial\s+|NotInheritable\s+|MustInherit\s+)*Class\s+',s,re.M|re.I)); ecl=len(re.findall(r'^\s*End\s+Class\b',s,re.M|re.I))
    sub=len(re.findall(r'^\s*(?:Public|Private|Friend|Protected)\s+(?:(?:Shared|Overrides)\s+)*Sub\s+',s,re.M|re.I)); esub=len(re.findall(r'^\s*End\s+Sub\b',s,re.M|re.I))
    fun=len(re.findall(r'^\s*(?:Public|Private|Friend|Protected)\s+(?:(?:Shared|Overrides)\s+)*Function\s+',s,re.M|re.I)); efun=len(re.findall(r'^\s*End\s+Function\b',s,re.M|re.I))
    if ns!=ens: errors.append(f'{p.name}: Namespace {ns}/{ens}')
    if cl!=ecl: errors.append(f'{p.name}: Class {cl}/{ecl}')
    if sub!=esub: errors.append(f'{p.name}: Sub {sub}/{esub}')
    if fun!=efun: errors.append(f'{p.name}: Function {fun}/{efun}')
if errors:
    print('FAIL'); [print('-',e) for e in errors]; sys.exit(1)
print('PASS: VB structural block balance')
