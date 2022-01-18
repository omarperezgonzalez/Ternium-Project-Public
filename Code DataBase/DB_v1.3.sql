-- CREACIÓN DE TABLAS
/* 
    CREATE TABLE Avatar (
        AvatarID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Avatar PRIMARY KEY CLUSTERED (AvatarID),
        -- Avatar characteristics
        SkinColor INT NOT NULL,
        Eyes INT NOT NULL,
        Eyebrows INT NOT NULL,
        Mouth INT NOT NULL,
        HairStyle INT NOT NULL,
        HairColor INT NOT NULL,
        FacialHair INT NOT NULL,
        Clothes INT NOT NULL,
        FabricColor INT NOT NULL,
        Glasses INT NOT NULL,
        GlassesOpac INT NOT NULL,
        Accesories INT NOT NULL,
        Tattoos INT NOT NULL,
        BackgroundColor INT NOT NULL
    );


    CREATE TABLE UserInfo (
        UserInfoID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_UserInfo PRIMARY KEY CLUSTERED (UserInfoID),
        UserBio VARCHAR(140),
        Position VARCHAR(50),
        Age INT,
        PhoneNum VARCHAR(30),
        JoinDate DATETIME NOT NULL,
        UserWeb VARCHAR(30),
        UserGit VARCHAR(30),
        UserTw VARCHAR(30),
        UserIg VARCHAR(30),
        UserFb VARCHAR(30),
        LastConnection DATETIME
    );


    CREATE TABLE QUIZZ (
        QUIZZID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_QUIZZ PRIMARY KEY CLUSTERED (QUIZZID),
        Name VARCHAR(30) NOT NULL,
        PlayedTime TIME NOT NULL,
        Level INT NOT NULL,
        NumCorrAns INT NOT NULL,
        NumWroAns INT NOT NULL,
        TotalAns INT NOT NULL,
        Tries INT NOT NULL,
        TimeByQ TIME,
        Score INT NOT NULL
    );


    CREATE TABLE RPG (
        RPGID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_RPG PRIMARY KEY CLUSTERED (RPGID),
        Name VARCHAR(30) NOT NULL,
        PlayedTime TIME NOT NULL,
        Level INT NOT NULL,
        Quests INT NOT NULL,
        TimeByQ TIME,
        Score INT NOT NULL
    );


    CREATE TABLE DECISIONES (
        DECISIONESID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_DECISIONES PRIMARY KEY CLUSTERED (DECISIONESID),
        Name VARCHAR(30) NOT NULL,
        PlayedTime FLOAT NOT NULL,
        Level INT NOT NULL,
        Decisions INT NOT NULL,
        Score INT NOT NULL
    );


    CREATE TABLE Game (
        GameID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Game PRIMARY KEY CLUSTERED (GameID),
        UserID INT,
        QUIZZID INT,
        RPGID INT,
        DECISIONESID INT,
        Name VARCHAR(30) NOT NULL,
        PlayedTime FLOAT NOT NULL,
        DayScore INT NOT NULL,
        WeekScore INT NOT NULL,
        Monthscore INT NOT NULL,
        OverallScore INT NOT NULL
    );


    CREATE TABLE Answer (
        AnswerID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Answer PRIMARY KEY CLUSTERED (AnswerID),
        QuestionID INT,
        CorrectAnswer INT NOT NULL,
        AnswerContent VARCHAR(50)
    )


    CREATE TABLE Question (
        QuestionID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Question PRIMARY KEY CLUSTERED (QuestionID),
        Question VARCHAR(50) NOT NULL,
        Status INT NOT NULL,
        Theme VARCHAR(30), -- Podría ser un INT para diferentes opciones
        Difficulty INT NOT NULL
    )


    CREATE TABLE Activity (
        ActivityID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Activity PRIMARY KEY CLUSTERED (ActivityID),
        ActivityContent VARCHAR(50),
        Theme VARCHAR(30)
    );


    CREATE TABLE dbo.[User] (
        UserID INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_User PRIMARY KEY CLUSTERED (UserID),
        AvatarID INT,
        UserInfoID INT,
        Name VARCHAR(30) NOT NULL,
        Email VARCHAR(30) NOT NULL,
        Password VARCHAR(30) NOT NULL,
        Status INT NOT NULL,
        TypeUser INT NOT NULL
    );


    CREATE TABLE UserTask (
        UserTaskID  INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_UserTask PRIMARY KEY CLUSTERED (UserTaskID),
        UserID INT,
        Description VARCHAR(50),
        TaskDate DATETIME NOT NULL,
        TaskStatus INT NOT NULL -- Definir el tipo
    );


    CREATE TABLE dbo.[Log] (
        LogID  INT IDENTITY (1,1) NOT NULL, CONSTRAINT PK_Log PRIMARY KEY CLUSTERED (LogID),
        UserID INT,
        ActivityID INT,
        AnswerID INT,
        LogDate DATETIME NOT NULL,
        LogType INT NOT NULL -- Definir el tipo
    ); 
*/


-- CREAR FOREIGN KEYS Y REINICIAR IDs A 1
/* 
    ALTER TABLE dbo.Game ADD CONSTRAINT FK_Game_User FOREIGN KEY (UserID) REFERENCES dbo.[User] (UserID);
    ALTER TABLE dbo.Game ADD CONSTRAINT FK_Game_QUIZZ FOREIGN KEY (QUIZZID) REFERENCES dbo.QUIZZ (QUIZZID);
    ALTER TABLE dbo.Game ADD CONSTRAINT FK_Game_RPG FOREIGN KEY (RPGID) REFERENCES dbo.RPG (RPGID);
    ALTER TABLE dbo.Game ADD CONSTRAINT FK_Game_DECISIONES FOREIGN KEY (DECISIONESID) REFERENCES dbo.DECISIONES (DECISIONESID);
    ALTER TABLE dbo.Answer ADD CONSTRAINT FK_Answer_Question FOREIGN KEY (QuestionID) REFERENCES dbo.Question (QuestionID);
    ALTER TABLE dbo.[User] ADD CONSTRAINT FK_User_Avatar FOREIGN KEY (AvatarID) REFERENCES dbo.Avatar (AvatarID);
    ALTER TABLE dbo.[User] ADD CONSTRAINT FK_User_UserInfo FOREIGN KEY (UserInfoID) REFERENCES dbo.UserInfo (UserInfoID);
    ALTER TABLE dbo.UserTask ADD CONSTRAINT FK_UserTask_User FOREIGN KEY (UserID) REFERENCES dbo.[User] (UserID);
    ALTER TABLE dbo.Log ADD CONSTRAINT FK_Log_User FOREIGN KEY (UserID) REFERENCES dbo.[User] (UserID);
    ALTER TABLE dbo.Log ADD CONSTRAINT FK_Log_Activity FOREIGN KEY (ActivityID) REFERENCES dbo.Activity (ActivityID);
    ALTER TABLE dbo.Log ADD CONSTRAINT FK_Log_Answer FOREIGN KEY (AnswerID) REFERENCES dbo.Answer (AnswerID);

    DBCC CHECKIDENT ('dbo.[Avatar]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[QUIZZ]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[RPG]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[DECISIONES]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[Game]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[Question]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[Answer]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[Activity]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[Log]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[UserInfo]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[UserTask]', RESEED, 1);
    DBCC CHECKIDENT ('dbo.[User]', RESEED, 1); 
*/


-- ELIMINAR LAS FK Y TABLAS
/*
    ALTER TABLE dbo.Game DROP CONSTRAINT FK_Game_User;
    ALTER TABLE dbo.Game DROP CONSTRAINT FK_Game_QUIZZ;
    ALTER TABLE dbo.Game DROP CONSTRAINT FK_Game_RPG;
    ALTER TABLE dbo.Game DROP CONSTRAINT FK_Game_DECISIONES;
    ALTER TABLE dbo.Answer DROP CONSTRAINT FK_Answer_Question;
    ALTER TABLE dbo.[User] DROP CONSTRAINT FK_User_Avatar;
    ALTER TABLE dbo.[User] DROP CONSTRAINT FK_User_UserInfo;
    ALTER TABLE dbo.UserTask DROP CONSTRAINT FK_UserTask_User;
    ALTER TABLE dbo.Log DROP CONSTRAINT FK_Log_User;
    ALTER TABLE dbo.Log DROP CONSTRAINT FK_Log_Activity;
    ALTER TABLE dbo.Log DROP CONSTRAINT FK_Log_Answer;

    DROP TABLE IF EXISTS Avatar;
    DROP TABLE IF EXISTS QUIZZ;
    DROP TABLE IF EXISTS RPG;
    DROP TABLE IF EXISTS DECISIONES;
    DROP TABLE IF EXISTS Game;
    DROP TABLE IF EXISTS Question;
    DROP TABLE IF EXISTS Answer;
    DROP TABLE IF EXISTS Activity;
    DROP TABLE IF EXISTS Log;
    DROP TABLE IF EXISTS UserInfo;
    DROP TABLE IF EXISTS UserTask;
    DROP TABLE IF EXISTS [User];
*/


-- INSERTS DE PRUEBA
/* 
    INSERT INTO dbo.Avatar 
    (SkinColor, Eyes, Eyebrows, Mouth, HairStyle, HairColor, FacialHair, Clothes, FabricColor, Glasses, GlassesOpac, Accesories, Tattoos, BackgroundColor) VALUES 
    (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14), 
    (2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1), 
    (3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2),
    (4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2, 3),
    (5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2, 3, 4);

    INSERT INTO dbo.QUIZZ
    (Name, PlayedTime, Level, NumCorrAns, NumWroAns, TotalAns, Tries, TimeByQ, Score) VALUES
    ('QUIZZ', '00:59:59', 1, 2, 3, 5, 1, '00:10:10', 123),
    ('QUIZZ', '01:00:00', 2, 3, 4, 7, 3, '00:11:00', 234),
    ('QUIZZ', '11:11:11', 3, 4, 5, 9, 4, '01:22:00', 345);

    INSERT INTO dbo.RPG 
    (Name, PlayedTime, Level, Quests, TimeByQ, Score) VALUES
    ('RPG', '10:10:10', 1, 2, '05:05:05', 123),
    ('RPG', '09:09:09', 2, 3, '03:03:03', 234),
    ('RPG', '01:00:00', 3, 4, '00:15:00', 345);

    INSERT INTO dbo.DECISIONES 
    (Name, PlayedTime, Level, Decisions, Score) VALUES
    ('DECISIONES', 0.01, 1, 11, 123),
    ('DECISIONES', 1.10, 2, 5, 234);

    INSERT INTO dbo.Question
    (Question, Status, Theme, Difficulty) VALUES
    ('¿Qué pesa más: Un kilo de plumas o uno de metal?', 1, 'Cultura', 2),
    ('2 + 2 = ', 0, 'Matematicas', 1),
    ('Selecciona la respuesta correcta', 1, 'Prueba', 1),
    ('¿Jorge Barbilla?', 1, 'Secreta', 3);

    INSERT INTO dbo.Answer
    (QuestionID, CorrectAnswer, AnswerContent) VALUES
    (1, 1, 'Igual'),
    (1, 1, 'Plumas'),
    (1, 1, 'Metal'),
    (1, 1, 'No sé'),
    (2, 5, '4'),
    (2, 5, '5'),
    (2, 5, '3'),
    (2, 5, 'Todas'),
    (3, 9, 'Correcta'),
    (3, 9, 'Errónea'),
    (3, 9, 'Trampa'),
    (3, 9, 'Esta no'),
    (4, 13, 'Es verdad'),
    (4, 13, 'Cierto'),
    (4, 13, 'Así es'),
    (4, 13, 'No');

    INSERT INTO dbo.Activity
    (ActivityContent, Theme) VALUES
    ('Login', 'Login'),
    ('Actualizacion de info', 'Info');

    INSERT INTO dbo.UserInfo
    (UserBio, Position, Age, PhoneNum, JoinDate, UserWeb, UserGit, UserTw, UserIg, UserFb, LastConnection) VALUES
    ('Me llamo pompilio pero me dicen pompi', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'pompi.com', '@pompi', '@pompi', '@pompi', '@pompi', '2021-03-07 07:00:00'),
    ('Me llamo agripino pero me dicen agri', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'agri.com', '@agri', '@agri', '@agri', '@agri', '2021-03-07 07:00:00'),
    ('Me llamo celestina pero me dicen tina', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'tina.com', '@tina', '@tina', '@tina', '@tina', '2021-03-07 07:00:00'),
    ('Me llamo hermenegildo pero me dicen hermes', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'hermes.com', '@hermes', '@hermes', '@hermes', '@hermes', '2021-03-07 07:00:00'),
    ('Me llamo macario y me gusta el guajolote', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'guajolotelover.com', '@guajolotelover', '@guajolotelover', '@guajolotelover', '@guajolotelover', '2021-03-07 07:00:00');

    INSERT INTO dbo.[User]
    (AvatarID, UserInfoID, Name, Email, Password, Status, TypeUser) VALUES 
    (1, 1, 'Pompilio', 'pompi@gmail.com', 'contrasenia123', 1, 1), 
    (2, 2, 'Agripino', 'agri@gmail.com', 'pizzaytaquitos0', 1, 2), 
    (3, 3, 'Celestina', 'tina@gmail.com', 'GrrMalditoConejo', 0, 3), 
    (4, 4, 'Hermenegildo', 'hermes@gmail.com', 'nosequeponer1', 0, 1), 
    (5, 5, 'Macario', 'macario@gmail.com', 'elguajoloteesmio3', 0, 1);

    INSERT INTO dbo.Game
    (UserID, QUIZZID, RPGID, DECISIONESID, Name, PlayedTime, DayScore, WeekScore, Monthscore, OverallScore) VALUES 
    (1, 1, NULL, NULL, 'QUIZZ', 0.1, 9, 99, 999, 9999),
    (2, NULL, 1, NULL, 'RPG', 1.0, 10, 20, 30, 40),
    (3, NULL, NULL, 1, 'DECISIONES', 0.1, 11, 11, 11, 11),
    (4, 2, NULL, NULL, 'QUIZZ', 1.0, 8, 100, 998, 10000),
    (5, NULL, 2, NULL, 'RPG', 0.1, 9, 18, 27, 45),
    (1, NULL, NULL, 2, 'DECISIONES', 1.0, 10, 20, 30, 40),
    (2, 3, NULL, NULL, 'QUIZZ', 0.1, 11, 11, 11, 11),
    (3, NULL, 3, NULL, 'RPG', 1.0, 9, 18, 27, 45);

    INSERT INTO dbo.UserTask
    (UserID, Description, TaskDate, TaskStatus) VALUES
    (1, 'Actualizar base de datos', '2021-03-07 06:59:41', 0),
    (1, 'Actualizar juegos', '2021-03-07 06:59:41', 1),
    (2, 'Actualizar pagina web', '2021-03-07 06:59:41', 0),
    (3, 'Actualizar otra cosa', '2021-03-07 06:59:41', 1),
    (4, 'Actualizar algo', '2021-03-07 06:59:41', 0),
    (5, 'Actualizar idk', '2021-03-07 06:59:41', 0);

    INSERT INTO dbo.Log
    (UserID, ActivityID, AnswerID, LogDate, LogType) VALUES
    (1, NULL, 1, '2021-03-07 06:59:41', 1),
    (2, NULL, 6, '2021-03-07 06:59:42', 1),
    (3, NULL, 11, '2021-03-07 06:59:43', 1),
    (4, NULL, 13, '2021-03-07 06:59:44', 1),
    (5, NULL, 2, '2021-03-07 06:59:41', 1),
    (1, NULL, 5, '2021-03-07 06:59:42', 1),
    (2, NULL, 10, '2021-03-07 06:59:43', 1),
    (3, NULL, 15, '2021-03-07 06:59:44', 1),
    (4, 1, NULL, '2021-03-07 06:59:44', 0),
    (5, 2, NULL, '2021-03-07 06:59:44', 0);
*/


-- SELECTS DE PRUEBA
/*
    SELECT * FROM dbo.Avatar;
    SELECT * FROM dbo.QUIZZ;
    SELECT * FROM dbo.RPG;
    SELECT * FROM dbo.DECISIONES;
    SELECT * FROM dbo.Game;
    SELECT * FROM dbo.Question;
    SELECT * FROM dbo.Answer;
    SELECT * FROM dbo.Activity;
    SELECT * FROM dbo.Log;
    SELECT * FROM dbo.UserInfo;
    SELECT * FROM dbo.[User]; 
    SELECT * FROM dbo.UserTask;
*/

/*
    -- TABLERO de RANKING
    SELECT [User].Name, UserInfo.Position, Game.PlayedTime, Game.OverallScore
    FROM dbo.[User]
    JOIN dbo.Game ON [User].UserID = Game.UserID
    JOIN dbo.UserInfo ON [User].UserInfoID = UserInfo.UserInfoID
    ORDER BY OverallScore DESC, PlayedTime ASC;

    -- TABLERO de Puntuacion
    SELECT DISTINCT [User].Name, Game.DayScore
    FROM dbo.[User]
    JOIN dbo.Game ON [User].UserID = Game.UserID
    ORDER BY [DayScore] DESC;

    -- Tablero por juego de niveles y puntos
    SELECT * FROM [User];
    SELECT * FROM Game;
    SELECT * FROM QUIZZ;

    SELECT [User].Name, QUIZZ.Level, QUIZZ.PlayedTime, QUIZZ.Score
    FROM dbo.[User]
    JOIN dbo.Game ON [User].UserID = Game.UserID
    JOIN dbo.QUIZZ ON Game.QUIZZID = QUIZZ.QUIZZID
    ORDER BY QUIZZ.Score DESC;

    SELECT [User].Name, RPG.Level, RPG.PlayedTime, RPG.Score
    FROM dbo.[User]
    JOIN dbo.Game ON [User].UserID = Game.UserID
    JOIN dbo.RPG ON Game.RPGID = RPG.RPGID
    ORDER BY RPG.Score DESC;

    SELECT [User].Name, DECISIONES.Level, DECISIONES.PlayedTime, DECISIONES.Score
    FROM dbo.[User]
    JOIN dbo.Game ON [User].UserID = Game.UserID
    JOIN dbo.DECISIONES ON Game.DECISIONESID = DECISIONES.DECISIONESID
    ORDER BY DECISIONES.Score DESC;

    -- Perfil User
    SELECT u.Name, u.Email, i.Age, i.PhoneNum, i.JoinDate, i.UserWeb, i.UserGit, i.UserTw, i.UserIg, i.UserFb
    FROM dbo.[User] as u
    JOIN dbo.UserInfo as i ON u.UserInfoID = i.UserInfoID
    WHERE u.Email = 'pompi@gmail.com';
*/



-- Stored Procedures
-- Crear SP
/* CREATE PROCEDURE dbo.[Table]   
    @Var1 TYPE(30),   
    @Var2 TYPE   
AS   
    Query
*/

-- Borrar y modificar
/* IF OBJECT_ID ( 'dbo.Register', 'P' ) IS NOT NULL   
    DROP PROCEDURE dbo.Register;   
*/

-- Login User
/* CREATE PROCEDURE dbo.LoginUser   
    @Email nvarchar(30),   
    @Password nvarchar(30)   
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
    @Email VARCHAR(30)
AS
    DELETE FROM dbo.[User] WHERE Email = @Email;
*/

-- ShowProfile
/* CREATE PROCEDURE dbo.ShowProfile 
    @Email VARCHAR(30)
AS
    SELECT u.Name, u.Email, i.Age, i.PhoneNum, i.JoinDate, i.UserWeb, i.UserGit, i.UserTw, i.UserIg, i.UserFb
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


-- EXECUTEs de Prueba

-- EXECUTE dbo.LoginUser @Email = 'pompi@gmail.com', @Password = 'contrasenia123';
-- EXECUTE dbo.LoginAdmin @Email = 'tina@gmail.com', @Password = 'GrrMalditoConejo';
-- EXECUTE dbo.ShowRanking;
-- EXECUTE dbo.Register @Name = 'Jose', @Email = 'jose@gmail.com', @Password = 'contrasenia', @TypeUser = 1;
-- EXECUTE dbo.DeleteUser @Email = 'jose@gmail.com';
-- EXECUTE dbo.ShowProfile @Email = 'pompi@gmail.com';

-- Versión js
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
    EXECUTE dbo.DeleteUser @Email = "'" + req.body.user + "'";

    Mostrar perfil de usuario
    EXECUTE dbo.ShowProfile @Email = "'" + req.body.user + "'"; 
*/


-- TRIGGERS

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



-- OTRAS FUNCIONES UTILES
-- DELETE FROM dbo.Tabla WHERE condicion = true;
-- ALTER TABLE dbo.Tabla ADD Columna TIPO; <- Añadir columnas

-- UPDATE dbo.Tabla SET Columna = VALOR WHERE ID = #; <- Modificar valores

-- SELECT * FROM sysobjects WHERE name LIKE 'FK_%' -- Muestra los constraints de todas las Foreign Keys
-- DBCC CHECKIDENT ('dbo.Users', RESEED, 1); -- Reseteo de PK


-- CREACION DE LOGIN Y USERS EN LA BASE DE DATOS
-- CREATE LOGIN Omarsin12 WITH PASSWORD = 'Pillos25' -- Haz esto desde master
/* CREATE USER Omarsin12 FOR LOGIN Omarsin12 WITH DEFAULT_SCHEMA = dbo;
ALTER ROLE db_owner ADD MEMBER Omarsin12; 
ALTER ROLE db_owner ADD MEMBER Omarsin12; */ -- haz esto desde la base de datos