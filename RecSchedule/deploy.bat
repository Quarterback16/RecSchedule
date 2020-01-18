::  Batch file to copy new app to Prod
xcopy e:\FileSync\SyncProjects\RecSchedule2\RecSchedule\bin\Release\netcoreapp3.1\*.dll c:\apps\RecSched /y
xcopy e:\FileSync\SyncProjects\RecSchedule2\RecSchedule\bin\Release\netcoreapp3.1\*.exe c:\apps\RecSched /y
xcopy e:\FileSync\SyncProjects\RecSchedule2\RecSchedule\bin\Release\netcoreapp3.1\*.json c:\apps\RecSched /y

