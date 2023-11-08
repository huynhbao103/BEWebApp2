use master 
go 
select name[Database Name],
SUSER_SNAME(owner_sid)[Database Owner], 
create_date [Database Create Date] 
from sys.databases 

Exec sp_changedbowner [sa]