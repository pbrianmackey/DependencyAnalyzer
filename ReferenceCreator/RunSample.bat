:REM This file is obsolete

@echo off
set arg1=%1
set arg2=%2

echo on
"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro projectReferences('%arg1%','%arg2%')

"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReference('%arg1%','%arg2%')

"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD1('%arg1%','%arg2%')

"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro transitiveReferenceD2('%arg1%','%arg2%')