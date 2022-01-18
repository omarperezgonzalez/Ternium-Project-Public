-- TRIGGERS

-- Creación de Trigger
/* 
    CREATE TRIGGER TriggerName
    ON dbo.[TriggeringTable]
    AFTER Query[INSERT, ALTER, UPDATE]
    AS
        Query[INSERT, ALTER, UPDATE]
 */

-- Creación de Avatar para User
/* CREATE TRIGGER RegisterAvatar
ON dbo.[User]
AFTER INSERT
AS
    INSERT INTO dbo.Avatar 
    (SkinColor, Eyes, Eyebrows, Mouth, HairStyle, HairColor, FacialHair, Clothes, FabricColor, Glasses, GlassesOpac, Accesories, Tattoos, BackgroundColor) VALUES 
    (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14); -- Buscar como hacerlos aleatorios 
*/

-- Actualización de User con Avatar
/* CREATE TRIGGER RegisterAvatar2
ON dbo.Avatar
AFTER INSERT
AS
    UPDATE dbo.[User] SET 
    AvatarID = 
    (SELECT AvatarID FROM inserted)
    WHERE dbo.[User].AvatarID IS NULL; 
*/

-- Creación de UserInfo para User
/* CREATE TRIGGER RegisterInfo
ON dbo.[User]
AFTER INSERT
AS
    INSERT INTO dbo.UserInfo 
    (JoinDate, LastConnection) VALUES
    (GETDATE(), GETDATE()); 
*/

-- Actualización de User con UserInfo
/* CREATE TRIGGER RegisterInfo2
ON dbo.UserInfo
AFTER INSERT
AS
    UPDATE dbo.[User] SET 
    UserInfoID = 
    (SELECT UserInfoID FROM inserted)
    WHERE dbo.[User].UserInfoID IS NULL; 
*/

-- Actualización ActivityID en Log
/* CREATE TRIGGER UpdateActivityLog
ON dbo.Activity
AFTER INSERT
AS 
    UPDATE dbo.[Log] SET
    Log.ActivityID = 
    (SELECT TOP 1 ActivityID FROM dbo.Activity
    ORDER BY ActivityID DESC)
    WHERE Log.ActivityID IS NULL AND Log.LogType = 2; */

-- DROP TRIGGER IF EXISTS UpdateActivityLog;
-- DISABLE TRIGGER