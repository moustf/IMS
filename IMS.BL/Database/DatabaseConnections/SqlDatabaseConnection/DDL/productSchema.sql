USE IMS;
GO

IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'product'
)
    BEGIN
        CREATE TABLE product (
                                 id INT PRIMARY KEY IDENTITY(1, 1),
                                 name NVARCHAR(50) NOT NULL,
                                 price DECIMAL(12, 4) NOT NULL,
                                 quantity INT NOT NULL,
        )
    END;