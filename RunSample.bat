@echo off
set arg1=%1
set arg2=%2

echo on
"D:\Program Files (x86)\swipl\bin\swipl.exe" -q -l .\Sample.pro projectReferences('%arg1%','%arg2%')