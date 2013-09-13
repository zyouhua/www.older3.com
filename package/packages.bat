@echo off
package.exe ../web/bin/ ../home/
cd ../web/bin/
del /F /S /Q *.pdb
echo open 58.64.199.147>>ftp.txt
echo zyouhua>>ftp.txt
echo 108AA116730c63>>ftp.txt
echo prompt off>>ftp.txt

echo prompt on>>ftp.txt
echo bye>>ftp.txt
ftp -s:ftp.txt
@echo on
