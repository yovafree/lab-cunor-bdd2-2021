@ECHO off
CLS
ECHO Date format = %date%

REM Breaking down the format 
FOR /f "tokens=2 delims==" %%G in ('wmic os get localdatetime /value') do set datetime=%%G
SET hora=%time:~0,2%_%time:~3,2%_%time:~6,2%

REM Building a timestamp from variables
SET "dd=%datetime:~6,2%"
SET "mth=%datetime:~4,2%"
SET "yyyy=%datetime:~0,4%"
SET "Date=%yyyy%%mth%%dd%"

set BKP_FILE=E:/backups_postgresql/bkp_%Date%_%hora%.backup

set PGPASSWORD=1234.6543

echo on

pg_dump -h 127.0.0.1 -p 5432 -U app_cunor -F c -b -v -f %BKP_FILE% bd_cunor

set PGPASSWORD=