from pathlib import Path
import sqlite3,sys,datetime
schema=(Path(__file__).resolve().parents[1]/'CarDealershipPOS/Data/schema.sql').read_text()
con=sqlite3.connect(':memory:'); con.execute('PRAGMA foreign_keys=ON'); con.executescript(schema)
now=datetime.datetime.utcnow().isoformat()
con.execute("insert into Users(Username,PasswordHash,PasswordSalt,Role,IsActive,CreatedAtUtc,UpdatedAtUtc) values(?,?,?,?,1,?,?)",('admin','h','s','Administrator',now,now))
uid=con.execute('select Id from Users').fetchone()[0]
con.execute("insert into Customers(CustomerNumber,FirstName,LastName,IsActive,CreatedAtUtc,UpdatedAtUtc) values('CUS-1','Ana','Buyer',1,?,?)",(now,now)); cid=con.execute('select Id from Customers').fetchone()[0]
con.execute("insert into Vehicles(StockNumber,Brand,Model,ModelYear,Condition,SellingPrice,Status,CreatedAtUtc,UpdatedAtUtc) values('STK-1','Toyota','GR86',2026,'New',2000000,'Available',?,?)",(now,now)); vid=con.execute('select Id from Vehicles').fetchone()[0]
# quotation does not sell stock
con.execute("insert into Quotations(QuoteNumber,CustomerId,UserId,Status,Subtotal,Discount,TaxRate,TaxAmount,Total,CreatedAtUtc) values('Q-1',?,?, 'Draft',2000000,0,12,240000,2240000,?)",(cid,uid,now)); qid=con.execute('select Id from Quotations').fetchone()[0]
con.execute('insert into QuotationItems(QuotationId,VehicleId,UnitPrice) values(?,?,2000000)',(qid,vid))
assert con.execute('select Status from Vehicles where Id=?',(vid,)).fetchone()[0]=='Available'
# finalize sample sale + payment + sold status
con.execute("insert into Sales(SaleNumber,CustomerId,UserId,QuotationId,Subtotal,Discount,TaxRate,TaxAmount,Total,PaymentPlan,Status,CreatedAtUtc) values('S-1',?,?,?,2000000,0,12,240000,2240000,'Installment','Completed',?)",(cid,uid,qid,now)); sid=con.execute('select Id from Sales').fetchone()[0]
con.execute('insert into SaleItems(SaleId,VehicleId,UnitPrice) values(?,?,2000000)',(sid,vid)); con.execute("update Vehicles set Status='Sold' where Id=?",(vid,)); con.execute("insert into Payments(SaleId,UserId,Amount,Method,PaidAtUtc) values(?,?,500000,'Cash',?)",(sid,uid,now)); con.commit()
bal=con.execute('select s.Total-coalesce(sum(p.Amount),0) from Sales s left join Payments p on p.SaleId=s.Id where s.Id=? group by s.Id',(sid,)).fetchone()[0]
assert abs(bal-1740000)<0.001
assert con.execute('select Status from Vehicles where Id=?',(vid,)).fetchone()[0]=='Sold'
print('PASS: schema + quotation/sale/payment workflow')
