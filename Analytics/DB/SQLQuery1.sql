use AHEAD

select SUM(Quantity), SUM(Amount) from payments where PaymentType = 'product charges' and sku = 'E3-2RHF-EO7C' and date = '2018-11-18' 
select * from payments where PaymentType = 'product charges' and orderid = '112-6143131-2531417'
select * from payments where PaymentType = 'product charges' and sku = 'E3-2RHF-EO7C'

select SUM(Quantity) from orders where purchasedate = '2018-11-18' and sku = 'E3-2RHF-EO7C' and saleschannel = 'Amazon.com'
select SUM(Quantity) from orders where lastupdateddate = '2018-11-18' and sku = 'E3-2RHF-EO7C' and saleschannel = 'Amazon.com'

select * from orders where purchasedate = '2018-11-18' and sku = 'E3-2RHF-EO7C' and saleschannel = 'Amazon.com'

select SUM(Quantity) from orders where purchasedate = '2018-11-17' and sku = 'E3-2RHF-EO7C' and saleschannel = 'Amazon.com' 


select * from orders where AmazonOrderId = '111-0001222-6097022'

select * from shipments where AmazonOrderId = '112-5427378-1177862'

select * from marketplace