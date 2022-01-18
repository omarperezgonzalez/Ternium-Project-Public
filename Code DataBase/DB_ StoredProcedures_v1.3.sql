-- Stored Procedures

-- Crear SP
/* CREATE PROCEDURE dbo.[SPName]   
    @Var1 TYPE(30),   
    @Var2 TYPE   
AS   
    Query
*/

-- Borrar y modificar SP
/* IF OBJECT_ID ( 'dbo.[UpdateUserInfo]', 'P' ) IS NOT NULL   
    DROP PROCEDURE dbo.[UpdateUserInfo];
*/


-- Login User
/* CREATE PROCEDURE dbo.LoginUser   
    @Email VARCHAR(30),   
    @Password VARCHAR(30)   
AS   
    SELECT * FROM dbo.[User] AS u WHERE u.Email = @Email AND  u.Password = @Password;
*/

-- Login Admin
/* CREATE PROCEDURE dbo.LoginAdmin   
    @Email VARCHAR(30),   
    @Password VARCHAR(30)   
AS   
    SELECT * FROM dbo.[User] AS u WHERE u.TypeUser = 3 AND u.Email = @Email AND  u.Password = @Password;
*/
-- Ranking
/* CREATE PROCEDURE dbo.ShowRanking 
AS
    SELECT u.Name, i.Position, g.PlayedTime, g.OverallScore 
    FROM dbo.[User] AS u 
    JOIN dbo.Game AS g ON u.UserID = g.UserID 
    JOIN dbo.UserInfo AS i ON u.UserInfoID = i.UserInfoID 
    ORDER BY g.OverallScore DESC, g.PlayedTime ASC;
*/
-- Register User
/* CREATE PROCEDURE dbo.Register 
    @Name VARCHAR(30),
    @Email VARCHAR(30),
    @Password VARCHAR(30),
    @TypeUser INT
AS
    INSERT INTO dbo.[User] 
    (Name, Email, Password, Status, TypeUser) VALUES
    (@Name, @Email, @Password, 1, @TypeUser);
*/
-- Delete User
/* CREATE PROCEDURE dbo.DeleteUser 
    @Email VARCHAR(30),
    @Password VARCHAR(30)   
AS   
    DELETE FROM dbo.[User] WHERE [User].Email = @Email AND  [User].Password = @Password;
*/
-- ShowProfile
/* CREATE PROCEDURE dbo.ShowProfile 
    @Email VARCHAR(30)
AS
    SELECT u.UserID, u.Name, u.Email, i.Age, i.PhoneNum, i.JoinDate, i.UserWeb, i.UserGit, i.UserTw, i.UserIg, i.UserFb
    FROM dbo.[User] as u
    JOIN dbo.UserInfo as i ON u.UserInfoID = i.UserInfoID
    WHERE u.Email = @Email;
*/
-- Logout
/* CREATE PROCEDURE dbo.Logout
    @Email VARCHAR(30)
AS
    UPDATE dbo.[User] SET [User].Status = 0 WHERE [User].Email = @Email; 
*/
-- ActiveUsers
/* CREATE PROCEDURE dbo.ActiveUsers 
AS   
    SELECT COUNT([User].[Status]) AS Active
    FROM dbo.[User] 
    WHERE [User].[Status] = 1 
*/
-- InactiveUsers
/* CREATE PROCEDURE dbo.InactiveUsers 
AS   
    SELECT COUNT([User].[Status]) AS Inactive
    FROM dbo.[User] 
    WHERE [User].[Status] = 0 
*/
-- ShowTasks
/* CREATE PROCEDURE dbo.ShowTasks
    -- @Email VARCHAR(30)
AS   
    SELECT t.Description AS ToDo, t.TaskDate AS CreationDate, t.TaskStatus AS Status
    FROM dbo.UserTask AS t
    JOIN dbo.[User] AS u ON t.UserID = u.UserID
    ORDER BY CreationDate
    -- WHERE u.Email = @Email; -- AND t.TaskStatus = 0;
*/
-- ShowActivity
/* CREATE PROCEDURE dbo.ShowActivity
    -- @Email VARCHAR(30)
AS   
    SELECT l.LogDate AS Date, a.ActivityContent AS Content
    FROM dbo.[Log] AS l
    JOIN dbo.Activity AS a ON l.ActivityID = a.ActivityID
    JOIN dbo.[User] AS u ON l.UserID = u.UserID
    ORDER BY Date DESC
    -- WHERE u.Email = @Email; 
 */
-- ShowGActivity
/* CREATE PROCEDURE dbo.ShowGActivity
    -- @Email VARCHAR(30)
AS   
    SELECT l.LogDate AS Date, q.Question AS Pregunta, a.AnswerContent AS Respuesta
    FROM dbo.[Log] AS l
    JOIN dbo.[User] AS u ON l.UserID = u.UserID
    JOIN dbo.Answer AS a ON l.AnswerID = a.AnswerID
    JOIN dbo.Question AS q ON a.QuestionID = q.QuestionID
    ORDER BY Date DESC
    -- WHERE u.Email = @Email; 
*/
-- UpdateUserInfo
/* CREATE PROCEDURE dbo.UpdateUserInfo
    @UserID VARCHAR(30),
    @Age INT,
    @PhoneNum VARCHAR(30),
    @UserWeb VARCHAR(30),
    @UserGit VARCHAR(30),
    @UserTw VARCHAR(30),
    @UserIg VARCHAR(30),
    @UserFb VARCHAR(30)
AS   
    UPDATE dbo.[UserInfo] SET 
    UserInfo.Age = @Age, UserInfo.PhoneNum = @PhoneNum, UserInfo.UserWeb = @UserWeb, UserInfo.UserGit = @UserGit, 
    UserInfo.UserTw = @UserTw, UserInfo.UserIg = @UserIg, UserInfo.UserFb = @UserFb
    FROM dbo.UserInfo AS i
    JOIN dbo.[User] AS u ON i.UserInfoID = u.UserInfoID
    WHERE u.UserID = @UserID;  */

-- UpdatePassword
/* CREATE PROCEDURE dbo.UpdatePassword
    @Email VARCHAR(30),
    @Password VARCHAR(30)
AS
    UPDATE dbo.[User] SET
    [User].[Password] = @Password
    WHERE [User].Email = @Email; 
*/
-- InsertActivity
/* CREATE PROCEDURE dbo.InsertActivity
    @ActivityContent VARCHAR(30),
    @UserID INT
AS
BEGIN
    INSERT INTO dbo.Log
    (UserID, LogDate, LogType) VALUES
    (@UserID, GETDATE(), 2);

    INSERT INTO dbo.Activity
    (ActivityContent, Theme) VALUES
    (@ActivityContent, 'Video');
END
 */

-- SaveAvatar
/* CREATE PROCEDURE dbo.SaveAvatar
    @UserID INT,
    @SkinColor INT,
    @Eyes INT,
    @Eyebrows INT,
    @Mouth INT,
    @HairStyle INT,
    @HairColor INT,
    @FacialHair INT,
    @Clothes INT,
    @FabricColor INT,
    @Glasses INT,
    @GlassesOpac INT,
    @Accesories INT,
    @Tattoos INT,
    @BackgroundColor INT
AS
    UPDATE dbo.[Avatar] SET 
    Avatar.SkinColor = @SkinColor, Avatar.Eyes = @Eyes, Avatar.Eyebrows = @Eyebrows, Avatar.Mouth = @Mouth, Avatar.HairStyle = @HairStyle, Avatar.HairColor = @HairColor, Avatar.FacialHair = @FacialHair, Avatar.Clothes = @Clothes, Avatar.FabricColor = @FabricColor, Avatar.Glasses = @Glasses, Avatar.GlassesOpac = @GlassesOpac, Avatar.Accesories = @Accesories, Avatar.Tattoos = @Tattoos, Avatar.BackgroundColor = @BackgroundColor
    FROM dbo.Avatar AS a
    JOIN dbo.[User] AS u ON a.AvatarID = u.AvatarID
    WHERE u.UserID = @UserID;
 */

/* EXECUTE dbo.SaveAvatar @SkinColor = "'" + req.body. + "'", @Eyes = "'" + req.body. + "'", @Eyebrows = "'" + req.body. + "'", @Mouth = "'" + req.body. + "'", 
@HairStyle = "'" + req.body. + "'", @HairColor = "'" + req.body. + "'", @FacialHair = "'" + req.body. + "'", @Clothes = "'" + req.body. + "'", @FabricColor = "'" + req.body. + "'", @Glasses = "'" + req.body. + "'", 
@GlassesOpac = "'" + req.body. + "'", @Accesories = "'" + req.body. + "'", @Tattoos = "'" + req.body. + "'", @BackgroundColor = "'" + req.body. + "'"; */


-- EXECUTE dbo.InsertActivity @ActivityContent = "'" + req.body. + "'", @Theme = "'" + req.body. + "'", @UserID = req.body.

-- EXECUTEs de Prueba
/* 
    -- EXECUTE dbo.LoginUser @Email = 'pompi@gmail.com', @Password = 'contrasenia123';
    -- EXECUTE dbo.LoginAdmin @Email = 'tina@gmail.com', @Password = 'GrrMalditoConejo';
    -- EXECUTE dbo.ShowRanking;
    -- EXECUTE dbo.Register @Name = 'Jose', @Email = 'jose@gmail.com', @Password = 'contrasenia', @TypeUser = 1;
    -- EXECUTE dbo.DeleteUser @Email = 'jose@gmail.com', @Password = 'contrasenia';
    -- EXECUTE dbo.ShowProfile @Email = 'pompi@gmail.com';
    -- EXECUTE dbo.ActiveUsers;
    -- EXECUTE dbo.InactiveUsers;
    -- EXECUTE dbo.ShowTasks;
    -- EXECUTE dbo.ShowActivity;
    -- EXECUTE dbo.ShowGActivity;
    -- EXECUTE dbo.UpdateUserInfo @UserID = "'" + req.body.id + "'", @Age = "'" + req.body. + "'", @PhoneNum = "'" + req.body. + "'", @UserWeb = "'" + req.body. + "'", @UserGit = "'" + req.body. + "'", @UserTw = "'" + req.body. + "'", @UserIg = "'" + req.body. + "'", @UserFb = "'" + req.body. + "'";
*/

-- Versión JS
/* 
    Inicio Usuario
    EXECUTE dbo.LoginUser @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'";

    Inicio Admin
    EXECUTE dbo.LoginAdmin @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'";

    Mostrar Ranking
    EXECUTE dbo.ShowRanking;

    Registro de usuario
    EXECUTE dbo.Register @Name = "'" + req.body.name + "'", @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'", @TypeUser = "'" + req.body.type + "'";

    Eliminación de usuario
    EXECUTE dbo.DeleteUser @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'";

    Mostrar perfil de usuario
    EXECUTE dbo.ShowProfile @Email = "'" + req.body.user + "'"; 

    Usuarios Activos
    EXECUTE dbo.ActiveUsers;

    Usuarios Inactivos
    EXECUTE dbo.InactiveUsers;

    Mostrar tareas del usuario
    EXECUTE dbo.ShowTasks @Email = "'" + req.body.user + "'";

    Mostrar actividad del usuario
    EXECUTE dbo.ShowActivity @Email = "'" + req.body.user + "'";

    Mostrar actividad de juegos
    EXECUTE dbo.ShowGActivity @Email = "'" + req.body.user + "'";
*/