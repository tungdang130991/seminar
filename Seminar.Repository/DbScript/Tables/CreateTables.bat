@echo off
for /R %%f in (*.sql) do (
	echo %%f
	mysql.exe -h 172.16.19.17 -P 3306 -u seminar --password=123456 -D seminar < "%%f"
)

set /p DUMMY=Hit ENTER to continue...