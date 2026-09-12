from pathlib import Path
import re,sys
root=Path(__file__).resolve().parents[1]/'CarDealershipPOS'; errors=[]
# quote/paren balance approximator and local type references
classes=set()
texts={}
for p in root.rglob('*.vb'):
    s=p.read_text(errors='ignore'); texts[p]=s
    for m in re.finditer(r'\b(?:Class|Module)\s+(\w+)',s,re.I): classes.add(m.group(1).lower())
    par=0; in_str=False; i=0
    while i<len(s):
        ch=s[i]
        if ch=='"':
            if in_str and i+1<len(s) and s[i+1]=='"': i+=2; continue
            in_str=not in_str
        elif not in_str:
            if ch=='(': par+=1
            elif ch==')': par-=1
            if par<0: errors.append(f'{p.name}: unmatched )'); break
        i+=1
    if in_str: errors.append(f'{p.name}: unclosed string literal approximation')
    if par!=0: errors.append(f'{p.name}: parentheses balance {par}')
for p,s in texts.items():
    for m in re.finditer(r'\bNew\s+([A-Za-z_]\w*(?:Form|Service|Repository))\b',s):
        n=m.group(1)
        if n.lower() not in classes: errors.append(f'{p.name}: unresolved project type {n}')

# VB.NET compile-risk patterns caught from real Visual Studio rebuilds.
for p,s in texts.items():
    for lineno,line in enumerate(s.splitlines(),1):
        code=line.strip()
        if re.search(r'(^|:|\bThen)\s*New\s+[A-Za-z_][A-Za-z0-9_.]*\([^)]*\)\.[A-Za-z_][A-Za-z0-9_]*\s*\(', code):
            errors.append(f'{p.name}:{lineno}: standalone New Type().Method() call is not valid VB statement syntax')
    if p.name.lower() == 'vehicle.vb' and re.search(r'\bPublic\s+Property\s+Variant\b', s, re.I):
        errors.append(f'{p.name}: Variant is a VB keyword and cannot be used unescaped as a property identifier')

# INSERT column/value arity on single-line SQL strings
alltext='\n'.join(texts.values())
for m in re.finditer(r'INSERT\s+(?:OR\s+IGNORE\s+)?INTO\s+\w+\s*\(([^\)]*)\)\s*VALUES\s*\(([^\)]*)\)',alltext,re.I):
    cols=[x.strip() for x in m.group(1).split(',') if x.strip()]
    vals=[x.strip() for x in m.group(2).split(',') if x.strip()]
    if len(cols)!=len(vals): errors.append(f'INSERT arity mismatch {len(cols)} columns/{len(vals)} values near {m.group(0)[:80]}')
if errors:
    print('FAIL'); [print('-',e) for e in errors[:100]]; sys.exit(1)
print('PASS: static VB reference/string/parenthesis/SQL sanity')
