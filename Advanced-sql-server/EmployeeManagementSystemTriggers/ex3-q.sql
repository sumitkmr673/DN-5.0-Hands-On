GO
CREATE TRIGGER trg_MaintenanceLogonRestrict_Test
ON ALL SERVER
FOR LOGON
AS
BEGIN
    DECLARE @CurrentTime TIME = CAST(GETDATE() AS TIME);

    IF @CurrentTime >= '07:40:00' AND @CurrentTime <= '07:45:00'
    BEGIN
        ROLLBACK;
    END
END;
GO