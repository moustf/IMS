IF NOT EXISTS (
		SELECT 1
		FROM sys.databases
		WHERE name = 'IMS'
		)
BEGIN
	CREATE DATABASE IMS;
END;
