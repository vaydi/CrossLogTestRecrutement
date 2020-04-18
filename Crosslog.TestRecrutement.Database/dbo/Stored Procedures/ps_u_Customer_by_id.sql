CREATE PROCEDURE ps_u_Customer_by_id

@CustomerId AS INT,
@LastName AS VARCHAR(50),
@FirstName AS VARCHAR(50),
@Address AS VARCHAR(50),
@ZipCode AS VARCHAR(50),
@City AS VARCHAR(50),
@Email AS VARCHAR(50),
@Phone AS VARCHAR(50)

AS
BEGIN

UPDATE Customers
   SET LastName = @LastName
      ,FirstName = @FirstName
      ,Address = @Address
      ,ZipCode = @ZipCode
      ,City = @City
      ,Email = @Email
      ,Phone = @Phone
 WHERE CustomerId = @CustomerId


END